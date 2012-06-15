using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using MarketScanner.Common;

namespace MarketScanner
{

    public partial class Main : Form
    {
        #region Fields

        private Hashtable _htAvailLogItems = new Hashtable(); // To hold available exported log items
        int _iItemSelectedHash; // Previous selected item in list, to be kept after reload
        readonly int[] _aiRegionSelectedHash = new int[2];
        readonly BestBargainTypes[] _abbtSelectedType = new BestBargainTypes[2];
        readonly bool[] _abDoneFirstRegionLoad = new bool[2];
        bool _isAnyMessageboxesOpen;
        bool _isMarketlogsLoaded;
        internal static bool IsAppOffline;
        long _iMinQuantityFilter;
        private readonly CultureInfo _ci = CultureInfo.CurrentCulture;
        public static string LightErrorMessage = string.Empty;
        private ContextMenuStrip _cmsSellersL = Values.SellersL;
        private ContextMenuStrip _cmsBuyersL = new ContextMenuStrip();
        private ContextMenuStrip _cmsSellersR = new ContextMenuStrip();
        private ContextMenuStrip _cmsBuyersR = new ContextMenuStrip();
        private const int SPACER = 4;
        private readonly ComboBox[] _aRegionComboboxes = new ComboBox[2];
        private int ColumnCount = 2;

        #endregion

        public Main()
        {
            // Uninstall Code -------------------
            string[] arguments = Environment.GetCommandLineArgs();
            foreach (string argument in arguments)
            {
                if (argument.Split('=')[0].ToLower() == "/u")
                {
                    string guid = argument.Split('=')[1];
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    ProcessStartInfo si = new ProcessStartInfo(path + "\\msiexec.exe", "/i " + guid);
                    Process.Start(si);
                    this.Close();
                    Application.Exit();
                    Environment.Exit(0); // Brute force Exit, to avoid any exeptions when uninstaller starts
                }
            }
            // End Uninstall Code ---------------



            InitializeComponent();
            //Set icon from application resource file
            this.Icon = Values.icoAppIcon;
        }


        private void LocalInit()
        {
            /* Initialize */

            // version
            String[] arrVersion = Application.ProductVersion.Split('.');
            string sIsDebug = string.Empty;
            // Insert debug string in version
#if (DEBUG)
            sIsDebug = " - Debug Build:";
#endif
            this.Text = Values.APP_TITLE;
            this.Text += sIsDebug;
            this.Text += string.Format(" v{0}.{1}.{2}", arrVersion);


            // Make reference arrray of region combos
            _aRegionComboboxes[0] = cbRegionsL;
            _aRegionComboboxes[1] = cbRegionsR;


            // Set tooltip display time
            ToolTipsInfo.InitialDelay = 1500;
            ToolTipsInfo.ReshowDelay = 1500;
            ToolTipsInfo.AutoPopDelay = 15000;

            // Set initial size of progressbar
            //ResizeSplitterDependents();


            // set market browser to previous state and rearrange dependents
            try { splitContainerMain.Panel1Collapsed = Values.IsMarketBrowserClosed; }
            catch (Exception exception)
            {
                LightErrorMessage += exception.Message;
            }




            // Initialize application controls state
            lblItemsChanged.Visible = false;
            lblDateExportedL.Visible = lblDateExportedTextL.Visible = false;
            lblDateExportedR.Visible = lblDateExportedTextR.Visible = false;
            lblRegions.SendToBack();
            RepositionRegionComboboxes();






            // Set initial values on controls
            _iMinQuantityFilter = Values.MinMarketQuantity; // Restore last entered value
            //tbMinQuantity.Text = string.Format(_ci, "{0:#,0}", _iMinQuantityFilter); ### Requires Boxing, so used alternate without boxing below:
            tbMinQuantity.Text = _iMinQuantityFilter.ToString("#,0", _ci);

            // Fill the system security dropdown with standard values
            this.DoSecurityComboFill();

            // Fill the Bargain finder dropdowns and set tooltips
            this.DoBargainComboFill();
            ToolTipsInfo.SetToolTip(cbBargainTypeL, Values.BARGAIN_FINDER_INFO);
            ToolTipsInfo.SetToolTip(cbBargainTypeR, Values.BARGAIN_FINDER_INFO);

            // Set path for logs
            try
            {
                FSWatcherLogs.Path = Values.MarketLogPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Values.MSG_ERROR);
            }

            // Set path for cache
            try
            {
                FSWatcherCache.Path = Values.CachedMethodCallsPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Values.MSG_ERROR);
            }

            #region Bind Events

            //Handler for Changed Event
            this.FSWatcherLogs.Changed += FSWatcher_Changed;
            //Handler for Created Event
            this.FSWatcherLogs.Created += FSWatcher_Created;
            //Handler for Deleted Event
            this.FSWatcherLogs.Deleted += FSWatcher_Deleted;
            //Handler for Renamed Event
            this.FSWatcherLogs.Renamed += FSWatcher_Renamed;
            //Handler for Changed Event
            this.FSWatcherCache.Changed += FSWatcherCache_Changed;
            //Handler for Created Event
            this.FSWatcherCache.Created += FSWatcherCache_Created;
            //Handler for Deleted Event
            this.FSWatcherCache.Deleted += FSWatcherCache_Deleted;
            //Handler for Renamed Event
            this.FSWatcherCache.Renamed += FSWatcherCache_Renamed;
            // Form Closing event
            this.FormClosing += Main_FormClosing;

            // Min Quantity box events
            this.tbMinQuantity.GotFocus += tbMinQuantity_GotFocus;
            this.tbMinQuantity.LostFocus += tbMinQuantity_LostFocus;
            this.tbMinQuantity.KeyPress += textBox_KeyPress;

            // DataGridView bindings
            this.dgvBuyersL.CellFormatting += Formatting.dataGridView_CellFormatting;
            this.dgvBuyersR.CellFormatting += Formatting.dataGridView_CellFormatting;
            this.dgvSellersL.CellFormatting += Formatting.dataGridView_CellFormatting;
            this.dgvSellersR.CellFormatting += Formatting.dataGridView_CellFormatting;

            this.dgvBuyersL.Sorted += Formatting.dataGridView_Sorted;
            this.dgvBuyersR.Sorted += Formatting.dataGridView_Sorted;
            this.dgvSellersL.Sorted += Formatting.dataGridView_Sorted;
            this.dgvSellersR.Sorted += Formatting.dataGridView_Sorted;

            // Add error messages on region change
            this.cbRegionsL.SelectedIndexChanged += LightErrorHandler;
            this.cbRegionsR.SelectedIndexChanged += LightErrorHandler;

            // Form resize
            this.Resize += Main_Resize;
            // When region combos are selected manually
            this.cbRegionsL.SelectionChangeCommitted += RegionCombosManuallySelected;
            this.cbRegionsR.SelectionChangeCommitted += RegionCombosManuallySelected;

            // Formatting for comboboxes
            this.cbItems.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbItems.DrawItem += Formatting.cbItalizeFirstItem_DrawItem;
            this.cbRegionsL.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbRegionsL.DrawItem += Formatting.cbItalizeFirstItem_DrawItem;
            this.cbRegionsR.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbRegionsR.DrawItem += Formatting.cbItalizeFirstItem_DrawItem;
            this.cbBargainTypeL.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbBargainTypeL.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbBargainTypeL.DrawItem += Formatting.cbItalizeFirstItem_DrawItem;
            this.cbBargainTypeR.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbBargainTypeR.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbBargainTypeR.DrawItem += Formatting.cbItalizeFirstItem_DrawItem;

            #endregion


            LightErrorHandler();
        }


        #region  Filesystem watchers

        /* DEFINE WATCHER EVENTS... */
        /// <summary>
        /// Event occurs when the contents of a File or Directory are changed
        /// </summary>
        private void FSWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            //lblEventType.Text = "Last Changed marketlog:";
            //code here for newly changed file or directory
            //lblLastcreated.Text = e.Name;
        }
        /// <summary>
        /// Event occurs when the a File or Directory is created
        /// </summary>
        private void FSWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            //code here for newly created file or directory
            toolStripLogFileStatus.Text = string.Format(" Last {0} marketlog: {1}", e.ChangeType.ToString().ToLower(), e.Name);
            ReloadMarketLogs();
            // Indicate that a file has been added
            lblItemsChanged.Visible = true;
        }
        /// <summary>
        /// Event occurs when the a File or Directory is deleted
        /// </summary>
        private void FSWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            //code here for newly deleted file or directory
            toolStripLogFileStatus.Text = string.Format(" Last {0} marketlog: {1}", e.ChangeType.ToString().ToLower(), e.Name);
            ReloadMarketLogs();
        }
        /// <summary>
        /// Event occurs when the a File or Directory is renamed
        /// </summary>
        private void FSWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            //code here for newly renamed file or directory
            toolStripLogFileStatus.Text = string.Format(" Last {0} marketlog: {1}", e.ChangeType.ToString().ToLower(), e.Name);
        }


        /* DEFINE WATCHER EVENTS... */
        /// <summary>
        /// Event occurs when the contents of a File or Directory are changed
        /// </summary>
        private void FSWatcherCache_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            //lblEventType.Text = "Last Changed marketlog:";
            //code here for newly changed file or directory
            ReloadMarketLogsFromCache();
            // Indicate that a file has been added
            lblItemsChanged.Visible = true;
        }
        /// <summary>
        /// Event occurs when a File or Directory is created
        /// </summary>
        private void FSWatcherCache_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            //code here for newly created file or directory
        }
        /// <summary>
        /// Event occurs when a File or Directory is deleted
        /// </summary>
        private void FSWatcherCache_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            //code here for newly deleted file or directory
        }
        /// <summary>
        /// Event occurs when a File or Directory is renamed
        /// </summary>
        private void FSWatcherCache_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            //code here for newly renamed file or directory
        }

        #endregion

        #region Methods


        /// <summary>
        /// Error handling for non-critical errors.
        /// </summary>
        private void LightErrorHandler()
        {
            if (LightErrorMessage == string.Empty || _isAnyMessageboxesOpen) return;

            LightErrorMessage += string.Format("{0}{1} can continue...", Environment.NewLine, Values.APP_TITLE);
            _isAnyMessageboxesOpen = true;
            MessageBox.Show(this, LightErrorMessage, "Non-critical error occcured");
            _isAnyMessageboxesOpen = false;
            LightErrorMessage = string.Empty;
        }

        // overload for event handling
        private void LightErrorHandler(object sender, EventArgs e) { LightErrorHandler(); }



        /// <summary>
        /// The initial load of Market logs. 
        /// ...
        /// TODO: write the rest...
        /// ...
        /// Fills the item ComboBox.
        /// </summary>
        private void LoadMarketLogs()
        {
            try
            {
                MarketLog ml;
                Parser p = new Parser();
                DirectoryInfo di = new DirectoryInfo(Values.MarketLogPath);
                Hashtable htItems = _htAvailLogItems;

                //reset market logs
                Values.dtMarketLogsListTable = DataHandler.CreateMarketLogsListTable();

                foreach (FileInfo fi in di.GetFiles())
                {
                    ml = p.parseMarketLog(fi, ref Values.dRegionNames);
                    if (ml != null)
                    {
                        Values.dtMarketLogsListTable.Rows.Add(DataHandler.MarketLogToDataRow(ml, Values.dtMarketLogsListTable));
                        // make list for item selection combobox, filter by date created from options
                        if (!htItems.Contains(ml.ItemHash))
                        {
                            // If Date filtering is set and logs created date is less than set date, then skip it.
                            if (Values.IsLogsDateFilterSet && ml.Created < Values.LogsDateFilter)
                            { /* skip */ }
                            else
                                htItems.Add(ml.ItemHash, ml);
                        }
                    }
                    // Step the progress bar
                    toolStripProgressBar1.PerformStep();
                    //pbGeneralProgressbar.PerformStep();
                }

                // Put the unique item in an arraylist to sort and use as datasource for combobox
                ArrayList alItems = new ArrayList();
                MarketLog mlFirstInlistMessage = new MarketLog { Item = "!!!" };
                alItems.Insert(0, mlFirstInlistMessage);
                alItems.InsertRange(1, htItems.Values);
                MarketLogComparer compareOn = new MarketLogComparer(MarketLogCompareField.Item);
                alItems.Sort(compareOn);

                // Check for any items at all
                _isMarketlogsLoaded = alItems.Count > 1;
                mlFirstInlistMessage.Item = _isMarketlogsLoaded ? Values.MSG_SELECT_ITEM : Values.MSG_NO_LOGS;

                cbItems.DataSource = alItems;
                cbItems.MaxDropDownItems = 25;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Values.MSG_ERROR);
            }
            // Clear the progressbar
            toolStripProgressBar1.Value = 0;

            // Load the market tree view
            if (!splitContainerMain.Panel1Collapsed && _isMarketlogsLoaded) ItemTreeView.LoadTreeView(ref _htAvailLogItems);

            LightErrorHandler();
        }


        internal void ReloadMarketLogs()
        {
            int iNewIndex = 0;

            // Clear the item hash table
            if (!splitContainerMain.Panel1Collapsed) _htAvailLogItems.Clear();

            // Reload all the logs 
            // TODO: Too Expensive.. find a smarter incremental way. Only load the new file
            LoadMarketLogs();

            // Set the previously selected item
            if (EnableBargainCombos(_iItemSelectedHash != 0))
            {
                MarketLog ml;
                for (int i = 0; i < cbItems.Items.Count; i++)
                {
                    ml = (MarketLog)cbItems.Items[i];
                    if (ml.ItemHash == _iItemSelectedHash)
                    {
                        iNewIndex = i;
                        break;
                    }
                }
                // Set the selected index or 0
                cbItems.SelectedIndex = iNewIndex;
            }

            LightErrorHandler();
        }


        /// <summary>
        /// The initial load of Market logs from cache files. 
        /// ...
        /// TODO: write the rest...
        /// ...
        /// Fills the item ComboBox.
        /// </summary>
        private void LoadMarketLogsFromCache()
        {
            try
            {
                MarketLog ml;
                Parser p = new Parser();

                //reset market logs
                Values.dtMarketLogsListTable = DataHandler.CreateMarketLogsListTable();

                EveCacheParser.Parser.SetCachedFilesFolders("CachedMethodCalls");
                EveCacheParser.Parser.SetIncludeMethodsFilter("GetOrders");
                FileInfo[] cachedFiles = EveCacheParser.Parser.GetMachoNetCachedFiles();
                DirectoryInfo di = new DirectoryInfo(Values.MarketLogPath + "\\Cache");
                if (!di.Exists)
                    di.Create();
                Hashtable htItems = _htAvailLogItems;

                //EVEMon's integrated unified uploader deletes cache files so we have to protect them
                foreach (FileInfo fi in cachedFiles)
                {
                    fi.CopyTo(Values.MarketLogPath + "\\Cache\\" + fi.Name, true);
                }

                foreach (FileInfo fi in di.GetFiles())
                {
                    ml = p.parseCachedMarketLog(fi, ref Values.dRegionNames);
                    if (ml != null)
                    {
                        Values.dtMarketLogsListTable.Rows.Add(DataHandler.MarketLogToDataRow(ml, Values.dtMarketLogsListTable));
                        // make list for item selection combobox, filter by date created from options
                        if (!htItems.Contains(ml.ItemHash))
                        {
                            // If Date filtering is set and logs created date is less than set date, then skip it.
                            if (Values.IsLogsDateFilterSet && ml.Created < Values.LogsDateFilter)
                            { /* skip */ }
                            else
                                htItems.Add(ml.ItemHash, ml);
                        }
                    }
                    // Step the progress bar
                    toolStripProgressBar1.PerformStep();
                    //pbGeneralProgressbar.PerformStep();
                }

                // Put the unique item in an arraylist to sort and use as datasource for combobox
                ArrayList alItems = new ArrayList();
                MarketLog mlFirstInlistMessage = new MarketLog { Item = "!!!" };
                alItems.Insert(0, mlFirstInlistMessage);
                alItems.InsertRange(1, htItems.Values);
                MarketLogComparer compareOn = new MarketLogComparer(MarketLogCompareField.Item);
                alItems.Sort(compareOn);

                // Check for any items at all
                _isMarketlogsLoaded = alItems.Count > 1;
                mlFirstInlistMessage.Item = _isMarketlogsLoaded ? Values.MSG_SELECT_ITEM : Values.MSG_NO_LOGS;

                cbItems.DataSource = alItems;
                cbItems.MaxDropDownItems = 25;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Values.MSG_ERROR);
            }
            // Clear the progressbar
            toolStripProgressBar1.Value = 0;

            // Load the market tree view
            if (!splitContainerMain.Panel1Collapsed && _isMarketlogsLoaded) ItemTreeView.LoadTreeView(ref _htAvailLogItems);

            LightErrorHandler();
        }

        internal void ReloadMarketLogsFromCache()
        {
            int iNewIndex = 0;

            // Clear the item hash table
            if (!splitContainerMain.Panel1Collapsed) _htAvailLogItems.Clear();

            // Reload all the logs 
            // TODO: Too Expensive.. find a smarter incremental way. Only load the new file
            LoadMarketLogsFromCache();

            // Set the previously selected item
            if (EnableBargainCombos(_iItemSelectedHash != 0))
            {
                MarketLog ml;
                for (int i = 0; i < cbItems.Items.Count; i++)
                {
                    ml = (MarketLog)cbItems.Items[i];
                    if (ml.ItemHash == _iItemSelectedHash)
                    {
                        iNewIndex = i;
                        break;
                    }
                }
                // Set the selected index or 0
                cbItems.SelectedIndex = iNewIndex;
            }

            LightErrorHandler();
        }

        /// <summary>
        /// Populates the marketlog views.
        /// </summary>
        /// <param name="mlSelected">The selected marketlog</param>
        /// <param name="bValidItem">If the marketlog is a valid Marketlog object</param>
        private bool MarketItemSelected(MarketLog mlSelected, bool bValidItem)
        {
            if (EnableBargainCombos(bValidItem))
            {
                MarketLog mlChosenItem = mlSelected;
                string sItem = DataHandler.ReplaceEscapeChars(mlChosenItem.Item);

                // Save Item hash for reselection if list changes
                _iItemSelectedHash = mlChosenItem.ItemHash;
                lblItemsChanged.Visible = false; // Reset notification

                DataRow[] drFoundRows = Values.dtMarketLogsListTable.Select("item = \'" + sItem + "\'", "region DESC, created DESC");

                Hashtable htRegions = new Hashtable();
                MarketLog ml;

                foreach (DataRow dr in drFoundRows)
                {
                    ml = DataHandler.DataRowToMarketLog(dr);

                    // If optional date filter is set in options, then filter logs
                    /*if (Values.IsLogsDateFilterSet && ml.Created <= Values.LogsDateFilter)
                    {
                            MessageBox.Show( "MARKETLOG FILTERED BY ITS DATE" );
                            continue;
                    }*/

                    // make list for item selection combobox
                    if (!htRegions.Contains(ml.RegionHash)) // if key exists
                    {
                        htRegions.Add(ml.RegionHash, ml);
                    }
                    else
                    { // compare dates of marketlog and replace if newer
                        MarketLog oldItem = (MarketLog)htRegions[ml.RegionHash];
                        if (oldItem.Created < ml.Created)
                        {
                            htRegions.Remove(ml.RegionHash);
                            htRegions.Add(ml.RegionHash, ml);
                        }
                    }
                }

                // Convert regions for current item to arraylist for comboboxes
                ArrayList alRegionsForCurrentItem = new ArrayList();
                MarketLog mlFirstInlistMessage = new MarketLog();
                mlFirstInlistMessage.Region = "!!!";
                alRegionsForCurrentItem.Insert(0, mlFirstInlistMessage);

                // Convert to arraylist for sorting
                foreach (MarketLog mlr in htRegions.Values)
                {
                    // If optional date filter is set in options, then filter logs
                    if (Values.IsLogsDateFilterSet && mlr.Created <= Values.LogsDateFilter) continue;

                    alRegionsForCurrentItem.Add(mlr);
                }

                MarketLogComparer compareOn = new MarketLogComparer(MarketLogCompareField.Region);
                alRegionsForCurrentItem.Sort(compareOn);
                mlFirstInlistMessage.Region = Values.MSG_SELECT_REGION;

                ArrayList alRegionsForCurrentItemClone = (ArrayList)alRegionsForCurrentItem.Clone();

                _abDoneFirstRegionLoad[0] = false;
                cbRegionsL.DataSource = alRegionsForCurrentItem;

                _abDoneFirstRegionLoad[1] = false;
                cbRegionsR.DataSource = alRegionsForCurrentItemClone;

                // Do a refresh after new item selected
                RefreshRegions();
            }
            return bValidItem;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbWithItems = (ComboBox)sender;

            if (MarketItemSelected((MarketLog)cbWithItems.SelectedItem, cbWithItems.SelectedIndex != 0))
            {
                ItemTreeView.SelectByTag(cbWithItems.SelectedItem);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal bool RefreshRegions()
        {
            bool wasAnyRegionsRefreshed = false;
            // Refresh each column
            for (int i = 0; i < ColumnCount; i++)
            {
                // Is the bargainfinder set for this column?
                if (_abbtSelectedType[i] > 0)
                {
                    FindBargain(_abbtSelectedType[i], ref _aRegionComboboxes[i]);
                }
                // check to see if a region was already selected and then reselect it (Also needed when min sec or quantity filters are changed)
                if (_aiRegionSelectedHash[i] != 0)
                {
                    ReselectRegion(_aRegionComboboxes[i], _aiRegionSelectedHash[i], i);
                    wasAnyRegionsRefreshed = true;
                }
                else //select first region for the leftmost column
                {
                    if (i == 0 && cbRegionsL.Items.Count > 0)
                    {
                        cbRegionsL.SelectedIndex = 1;
                        wasAnyRegionsRefreshed = true;
                    }
                }
            }
            return wasAnyRegionsRefreshed;
        }


        /// <summary>
        /// Resets the bargain combos when a region combo is change manually
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionCombosManuallySelected(object sender, EventArgs e)
        {
            ComboBox cbCurrent = (ComboBox)sender;
            if (cbCurrent.Name.IndexOf('L') != -1)
                cbBargainTypeL.SelectedIndex = 0;
            else
                cbBargainTypeR.SelectedIndex = 0;
        }

        /// <summary>
        /// Reslects the previously chosen region for a column.
        /// </summary>
        /// <param name="cb">The region combobox</param>
        /// <param name="iSelectedHash">The hash of the previously selected region</param>
        /// <param name="iColumn">The column to reselect to</param>
        private void ReselectRegion(ComboBox cb, int iSelectedHash, int iColumn)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                MarketLog ml = (MarketLog)cb.Items[i];
                if (iSelectedHash == ml.RegionHash)
                {
                    switch (iColumn)
                    {
                        case 0:
                            ml.ToGridView(ref dgvSellersL, ref dgvBuyersL, ref  _cmsSellersL, ref  _cmsBuyersL);
                            break;
                        case 1:
                            ml.ToGridView(ref dgvSellersR, ref dgvBuyersR, ref  _cmsSellersR, ref  _cmsBuyersR);
                            break;
                        default:
                            break;
                    }

                    cb.SelectedIndex = i;
                    // Region selected. No need to examine the rest.
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRegionsL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbLeft = (ComboBox)sender;
            if (cbLeft.SelectedIndex == 0)
            {
                if (_abDoneFirstRegionLoad[0])
                {
                    _aiRegionSelectedHash[0] = 0;
                    _abDoneFirstRegionLoad[0] = true;
                }
                dgvSellersL.DataSource = null;
                dgvBuyersL.DataSource = null;
                lblDateExportedL.Visible = lblDateExportedTextL.Visible = false;
                return;
            }
            MarketLog ml = (MarketLog)cbLeft.SelectedValue;

            // Save region hash for reselection if list changes
            _aiRegionSelectedHash[0] = ml.RegionHash;

            // Load log to gridviews
            ml.ToGridView(ref dgvSellersL, ref dgvBuyersL, ref  _cmsSellersL, ref  _cmsBuyersL);

            // Show date created
            lblDateExportedL.Visible = lblDateExportedTextL.Visible = true;
            lblDateExportedL.Text = ml.Created.ToShortDateString();
        }


        private void cbRegionsR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbRight = (ComboBox)sender;
            if (cbRight.SelectedIndex == 0)
            {
                if (_abDoneFirstRegionLoad[1])
                {
                    _aiRegionSelectedHash[1] = 0;
                    _abDoneFirstRegionLoad[1] = true;
                }
                dgvSellersR.DataSource = null;
                dgvBuyersR.DataSource = null;
                lblDateExportedR.Visible = lblDateExportedTextR.Visible = false;
                return;
            }
            MarketLog ml = (MarketLog)cbRight.SelectedValue;

            // Save region hash for reselection if list changes
            _aiRegionSelectedHash[1] = ml.RegionHash;

            // Load log to gridviews
            ml.ToGridView(ref dgvSellersR, ref dgvBuyersR, ref  _cmsSellersR, ref  _cmsBuyersR);

            // Show date created
            lblDateExportedR.Visible = lblDateExportedTextR.Visible = true;
            lblDateExportedR.Text = ml.Created.ToShortDateString();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*DialogResult dr = MessageBox.Show( "Exit " + Values.APP_TITLE + "?", "Exit application", MessageBoxButtons.OKCancel );
            if (dr == DialogResult.OK)
            {*/
            this.Close();
            this.Dispose();
            //}
        }


        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOptions frmOptions = new FrmOptions();
            frmOptions.Show(this);
        }


        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show(this);
        }



        void tbMinQuantity_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = _iMinQuantityFilter.ToString();
        }


        void tbMinQuantity_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            string sMinQuantity = tb.Text;
            long iQuantity;
            Int64.TryParse(sMinQuantity, NumberStyles.Any, _ci, out iQuantity);

            if (iQuantity == _iMinQuantityFilter) return;
            Values.MinMarketQuantity = _iMinQuantityFilter = iQuantity; // Remember the last entered value
            //tb.Text = string.Format(_ci, "{0:#,0}", iQuantity); Requires boxing
            tb.Text = iQuantity.ToString("#,0", _ci); // Boxing free :)
            RefreshRegions();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') // handle enter key as a tab but keep focus
            {
                e.Handled = true;

                tbMinQuantity_LostFocus(sender, e);
                tbMinQuantity.SelectAll();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
                // For Shift+tab:
                //System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
        }


        // On form resize
        void Main_Resize(object sender, EventArgs e)
        {
            RepositionRegionComboboxes();
        }

        private void RepositionRegionComboboxes()
        {
            int marketBrowserSize = splitContainerMain.Panel1Collapsed ? 0 : splitContainerMain.Panel1.Width + SPACER / 2;
            cbRegionsR.Left = (cbBargainTypeR.Left + cbBargainTypeR.Width + marketBrowserSize) - cbRegionsR.Width;
            cbRegionsL.Left = (cbBargainTypeL.Left + cbBargainTypeL.Width + marketBrowserSize) - cbRegionsL.Width;
            lblRegions.Left = SPACER + cbItems.Right;
            return;
        }

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ResizeSplitterDependents();
            RepositionRegionComboboxes();
        }

        void ResizeSplitterDependents()
        {
            toolStripProgressBar1.Width = splitContainerMain.Panel1.Width - SPACER;
            cbItems.Width = splitContainerMain.Panel1.Width - (2 * SPACER + lblItems.Width);
            lblItemsChanged.Left = splitContainerMain.Panel1.Width - 8 * SPACER;
        }

        #region "Bargain finder"

        /// <summary>
        /// Finds the best region on a particular bargain type i.e. Lowest Sell
        /// </summary>
        /// <param name="bbtType">The type of bargain selected by user.</param>
        /// <param name="cbRegions">The originating ComboBox.</param>
        private static void FindBargain(BestBargainTypes bbtType, ref ComboBox cbRegions)
        {
            int iCbIndex = 0;
            int iBargainIndex = 0;
            List<KeyValuePair<int, double>> dicPrices = new List<KeyValuePair<int, double>>();

            // Skip if no data
            if (cbRegions.DataSource == null) return;

            // Loop the marketlogs and add to list based on bargain type
            foreach (MarketLog ml in (ArrayList)cbRegions.DataSource)
            {
                // skip marketlog on empty filename
                if (ml.FileName == string.Empty) continue;
                // increment the index
                iCbIndex++;
                // add the High or Low value to dictionary
                dicPrices.Add(new KeyValuePair<int, double>(iCbIndex, ml.GetHighLowByBargainType(bbtType)));
            }

            // Sortings
            switch (bbtType)
            {
                case BestBargainTypes.HighestBuy:
                    dicPrices.Sort((firstPair, nextPair) => nextPair.Value.CompareTo(firstPair.Value));
                    iBargainIndex = dicPrices[0].Key;
                    break;
                case BestBargainTypes.SecondHighestBuy:
                    dicPrices.Sort((firstPair, nextPair) => nextPair.Value.CompareTo(firstPair.Value));
                    // second high/low price in different region
                    iBargainIndex = Utility.findSecondRegion(dicPrices);
                    break;
                // The lowest region of all the highest bidders
                // (Where to place your Buy orders)
                case BestBargainTypes.HighestBidderLowestRegion:
                    dicPrices.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));
                    iBargainIndex = dicPrices[0].Key;
                    break;
                case BestBargainTypes.SecondHighestBidderLowestRegion:
                    dicPrices.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));
                    // second high/low price in different region
                    iBargainIndex = Utility.findSecondRegion(dicPrices);
                    break;
                //-----------------------------------------------
                case BestBargainTypes.LowestSell:
                    dicPrices.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));
                    iBargainIndex = dicPrices[0].Key;
                    break;
                case BestBargainTypes.SecondLowestSell:
                    dicPrices.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));
                    // second high/low price in different region
                    iBargainIndex = Utility.findSecondRegion(dicPrices);
                    break;
                // The Highest region of the lowest sellers
                //(Where to place you Sell orders)
                case BestBargainTypes.LowestSellerHighestRegion:
                    dicPrices.Sort((firstPair, nextPair) => nextPair.Value.CompareTo(firstPair.Value));
                    iBargainIndex = dicPrices[0].Key;
                    break;
                case BestBargainTypes.SecondLowestSellerHighestRegion:
                    dicPrices.Sort((firstPair, nextPair) => nextPair.Value.CompareTo(firstPair.Value));
                    // second high/low price in different region
                    iBargainIndex = Utility.findSecondRegion(dicPrices);
                    break;
            }

            // Set the selected region in the referenced combobox
            if (iBargainIndex != 0) cbRegions.SelectedIndex = iBargainIndex;
        }


        private void cbBargainTypeL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            BestBargainTypes selectedBargainType = (BestBargainTypes)cb.SelectedIndex;
            FindBargain(selectedBargainType, ref cbRegionsL);
            _abbtSelectedType[0] = selectedBargainType;
        }

        private void cbBargainTypeR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            BestBargainTypes selectedBargainType = (BestBargainTypes)cb.SelectedIndex;
            FindBargain(selectedBargainType, ref cbRegionsR);
            _abbtSelectedType[1] = selectedBargainType;
        }

        private void ResetBargainCombos()
        {
            cbBargainTypeL.SelectedIndex = 0;
            cbBargainTypeR.SelectedIndex = 0;
        }

        private bool EnableBargainCombos(bool isEnabled)
        {
            cbBargainTypeL.Enabled = isEnabled;
            cbBargainTypeR.Enabled = isEnabled;
            return isEnabled;
        }

        /// <summary>
        /// 
        /// LowestSell = 1,
        /// HighestBuy,
        /// HighestBidderLowestRegion,
        /// LowestSellerHighestRegion,
        /// LowestBuy,
        /// HighestSell
        /// </summary>
        private void DoBargainComboFill()
        {
            EnableBargainCombos(false); // init 
            string[] sarrBargainType = new string[9] { "Find where to...", "Buy", "Buy (2nd)", "Sell", "Sell (2nd)", "Place buy order", "Place buy order (2nd)", "Place sell order", "Place sell order (2nd)" };//, "*Lowest Buy", "*Highest Sell" };
            cbBargainTypeL.DataSource = sarrBargainType.Clone();
            cbBargainTypeR.DataSource = sarrBargainType;
        }

        #endregion

        private void DoSecurityComboFill()
        {
            // Disable index changed event handler while filling combobox
            cbMinSysSec.SelectedIndexChanged -= cbMinSysSec_SelectedIndexChanged;
            // Create the double array of security values
            Double[] darrSysSec = new Double[12] { -1.0, 0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 };
            // Set the datasource
            cbMinSysSec.DataSource = darrSysSec;
            // Make sure an index is selected
            if (Values.MinSystemSecurity != 0)
            {
                for (int i = 0; i < darrSysSec.Length; i++)
                {
                    // Reselect previous value
                    if (darrSysSec[i] != Values.MinSystemSecurity) continue;
                    cbMinSysSec.SelectedIndex = i;
                    //break;
                }
            }
            else
            {
                cbMinSysSec.SelectedIndex = 0;
            }
            // Format the security values for local standards
            cbMinSysSec.FormatString = "F1";
            cbMinSysSec.FormattingEnabled = true;
            // Reenable the event handler
            cbMinSysSec.SelectedIndexChanged += new EventHandler(cbMinSysSec_SelectedIndexChanged);
        }

        private void cbMinSysSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            double dParseResult;
            double.TryParse(cb.SelectedValue.ToString(), out dParseResult);
            if (dParseResult != Values.MinSystemSecurity)
            {
                // If the value is changed. Set new value and resfresh the regions
                Values.MinSystemSecurity = dParseResult;
                RefreshRegions();
            }
        }

        private void tsbToggleItemBrowser_Click(object sender, EventArgs e)
        {
            Values.IsMarketBrowserClosed = splitContainerMain.Panel1Collapsed = !splitContainerMain.Panel1Collapsed;
            // update region comboboxes position
            RepositionRegionComboboxes();
            if (!splitContainerMain.Panel1Collapsed && _isMarketlogsLoaded)
            {
                ReloadMarketLogs();
            }
        }

        private void ItemTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectItemTreeItem(ItemTreeView.SelectedNode.Tag);
        }

        /// <summary>
        /// Select the item defined by mlMarketLog without causing a cbItems.SelectedIndexChanged event
        /// </summary>
        /// <param name="mlMarketLog">A marketlog</param>
        private void SelectItemTreeItem(object mlMarketLog)
        {
            if (!MarketItemSelected((MarketLog)mlMarketLog, mlMarketLog != null)) return;
            cbItems.SelectedIndexChanged -= cbItems_SelectedIndexChanged;
            cbItems.SelectedItem = mlMarketLog;
            cbItems.SelectedIndexChanged += cbItems_SelectedIndexChanged;
        }

        #endregion

        #region Saving and loading the window state and position

        /// <summary>
        /// Loads saved settings if any.
        /// Then starts local init.
        /// Loads marketlogs if option is set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            if (MarketScanner.Properties.Settings.Default.MySettingsUpgradeToNewVersion)
            {
                MarketScanner.Properties.Settings.Default.Upgrade();
                MarketScanner.Properties.Settings.Default.MySettingsUpgradeToNewVersion = false;
            }
            if (MarketScanner.Properties.Settings.Default.MyWindowSize != null)
            {
                this.Size = MarketScanner.Properties.Settings.Default.MyWindowSize;
                this.Location = MarketScanner.Properties.Settings.Default.MyWindowLoc;
                this.WindowState = MarketScanner.Properties.Settings.Default.MyWindowState;
            }

            // Do local initialization
            LocalInit();

            if (Values.UseCacheReader)
            {
                loadMarketLogsFromCacheToolStripMenuItem.Checked = true;
            }
            else
            {
                loadExportedMarketLogsToolStripMenuItem.Checked = true;
            }

            // Last init
            if (Values.LoadLogsOnStartup)
            {
                if (Values.UseCacheReader)
                {
                    LoadMarketLogsFromCache();
                    FSWatcherCache.EnableRaisingEvents = true;
                    FSWatcherLogs.EnableRaisingEvents = false;
                }
                else
                {
                    LoadMarketLogs();
                    FSWatcherLogs.EnableRaisingEvents = true;
                    FSWatcherCache.EnableRaisingEvents = false;
                }
            }
        }

        /// <summary>
        /// Saves window position on closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MarketScanner.Properties.Settings.Default.MyWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                MarketScanner.Properties.Settings.Default.MyWindowSize = this.Size;
                MarketScanner.Properties.Settings.Default.MyWindowLoc = this.Location;
            }
            else
            {
                MarketScanner.Properties.Settings.Default.MyWindowSize = this.RestoreBounds.Size;
                MarketScanner.Properties.Settings.Default.MyWindowLoc = this.RestoreBounds.Location;
            }
            MarketScanner.Properties.Settings.Default.Save();
        }

        #endregion



        #region "New unstable functionallity"

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Wallet w = new Wallet();
            w.Show();
        }



        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //ItemTreeView.LoadTreeView( ref _htAvailLogItems );
        }



        private void excludeSystemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarSystemsFilter starSystemsFilterWindow = new StarSystemsFilter();
            starSystemsFilterWindow.Show(this);
        }


        #endregion


        private void loadMarketLogsFromCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadMarketLogsFromCacheToolStripMenuItem.Checked == false)
            {
                loadExportedMarketLogsToolStripMenuItem.Checked = false;
                loadMarketLogsFromCacheToolStripMenuItem.Checked = true;
                Values.UseCacheReader = true;
            }
        }

        private void loadExportedMarketLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadExportedMarketLogsToolStripMenuItem.Checked == false)
            {
                loadExportedMarketLogsToolStripMenuItem.Checked = true;
                loadMarketLogsFromCacheToolStripMenuItem.Checked = false;
                Values.UseCacheReader = false;
            }
        }

        private void tsbLoadLogs_ButtonClick(object sender, EventArgs e)
        {
            if (loadMarketLogsFromCacheToolStripMenuItem.Checked == true)
            {
                LoadMarketLogsFromCache();
                FSWatcherCache.EnableRaisingEvents = true;
                FSWatcherLogs.EnableRaisingEvents = false;
            }
            if (loadExportedMarketLogsToolStripMenuItem.Checked == true)
            {
                LoadMarketLogs();
                FSWatcherCache.EnableRaisingEvents = false;
                FSWatcherLogs.EnableRaisingEvents = true;
            }
        }

    }
}
