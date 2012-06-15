using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace MarketScanner
{

    public class MarketLog
    {
        #region Properties

        private string _sRegion = string.Empty;
        public string Region
        {
            get { return _sRegion; }
            set
            {
                _sRegion = value;
                RegionHash = _sRegion.GetHashCode();
            }
        }

        public Int32 RegionHash { get; private set; }


        private string _sItem = string.Empty;
        public string Item
        {
            get { return _sItem; }
            set
            {
                _sItem = value;
                ItemHash = _sItem.GetHashCode();
            }
        }

        public Int32 ItemHash { get; private set; }

        private DateTime _dtCreated = DateTime.MinValue;
        public DateTime Created // This is Evetime
        {
            get { return _dtCreated; }
            set { _dtCreated = value; }
        }

        private string _sFileName = string.Empty;
        public string FileName
        {
            get { return _sFileName; }
            set { _sFileName = value; }
        }

        private string _sFilePath = string.Empty;
        public string FilePath
        {
            get { return _sFilePath; }
            set { _sFilePath = value; }
        }


        private DataTable MarketTable
        {
            get
            {
                DataTable dt = this.ToDataTable();
                DataTable dtfiltered = dt.Clone();

                //debug int count1 = dt.Rows.Count;

                DataRow[] aDr = dt.Select(string.Format("volRemaining >= {0} AND Security >= '{1}'", Values.MinMarketQuantity, Values.MinSystemSecurity));

                //debug int count2 = aDr.Length;
                for (int i = 0; i < aDr.Length; i++)
                {
                    dtfiltered.ImportRow(aDr[i]);
                }

                //debug int count3 = dtfiltered.Rows.Count;
                return dtfiltered;
            }
        }

        public double HighestBuy
        {
            get { return GetExtremePrice("MAX", true); }
        }

        public double LowestBuy
        {
            get { return GetExtremePrice("MIN", true); }
        }

        public double HighestSell
        {
            get { return GetExtremePrice("MAX", false); }
        }

        public double LowestSell
        {
            get { return GetExtremePrice("MIN", false); }
        }

        private DataView _dvSellers;
        private DataView _dvBuyers;

        #endregion





        #region Constructors
        //internal MarketLog(){}

        #endregion


        // HACK: for returning the region for the region combos
        // Overriding the ToString() method
        public override string ToString()
        {
            return this.Region;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable ToDataTable()
        {
            DataTable dtLog = null;
            if (File.Exists(this.FilePath)) //Check if file still exists
            {
                DataHandler dh = new DataHandler();
                switch (Path.GetExtension(this.FilePath))
                {
                    case ".txt":
                        FileStream fs = new FileStream(this.FilePath, FileMode.Open);

                        dtLog = dh.ProcessMarketLog(fs, FileDataTypes.Csv, Values.dtMarketLogsListTable.TableName, ref Values.slStationNames);
                        fs.Close();
                        break;
                    case ".cache":
                        dtLog = dh.ProcessCachedMarketLog(this.FilePath, Values.dtMarketLogsListTable.TableName, ref Values.slStationNames);
                        break;
                }

            }
            return dtLog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvSellers"></param>
        /// <param name="dgvBuyers"></param>
        /// <param name="cmsMainSellers"></param>
        /// <param name="cmsMainBuyers"></param>
        internal void ToGridView(ref MarketScanner.Common.BgPaintedDataGridView dgvSellers, ref MarketScanner.Common.BgPaintedDataGridView dgvBuyers, ref ContextMenuStrip cmsMainSellers, ref ContextMenuStrip cmsMainBuyers)
        {
            dgvSellers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvSellers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvSellers.SuspendLayout();
            dgvBuyers.SuspendLayout();
            if (File.Exists(this.FilePath)) //Check if file still exists
            {
                DataTable dtLog = MarketTable; // Get filtered MarketLog datatable
                if (dtLog != null)
                {
                    // Split between buyers and sellers
                    DataHandler.SplitLogEntries(ref dtLog, ref _dvSellers, ref _dvBuyers);

                    // modify view settings
                    _dvSellers.AllowNew = _dvBuyers.AllowNew = false;
                    _dvSellers.AllowDelete = _dvBuyers.AllowDelete = false;
                    _dvSellers.AllowEdit = _dvBuyers.AllowEdit = false;

                    // Set datasource before formatting
                    dgvSellers.DataSource = _dvSellers;
                    dgvBuyers.DataSource = _dvBuyers;
                    Formatting.FormatDataGridViewByType(ref dgvSellers, FormatDgvType.Sellers);
                    Formatting.FormatDataGridViewByType(ref dgvBuyers, FormatDgvType.Buyers);

                    // Set Context menus
                    GetContextMenuForDataGridView(ref dgvBuyers, ref cmsMainBuyers);
                    GetContextMenuForDataGridView(ref dgvSellers, ref cmsMainSellers);
                }
            }
            dgvSellers.ResumeLayout();
            dgvBuyers.ResumeLayout();
        }

        /// <summary>
        /// Mapping between BestBargainTypes Enum and marketlog properties
        /// </summary>
        /// <param name="bbt">BestBargainTypes</param>
        /// <returns>Proper property value</returns>
        internal double GetHighLowByBargainType(BestBargainTypes bbt)
        {
            switch (bbt)
            {
                case BestBargainTypes.SecondHighestBidderLowestRegion:
                case BestBargainTypes.HighestBidderLowestRegion:
                case BestBargainTypes.SecondHighestBuy:
                case BestBargainTypes.HighestBuy:
                    return HighestBuy;
                case BestBargainTypes.SecondLowestSellerHighestRegion:
                case BestBargainTypes.LowestSellerHighestRegion:
                case BestBargainTypes.SecondLowestSell:
                case BestBargainTypes.LowestSell:
                    return LowestSell;
                case BestBargainTypes.HighestSell:
                    return HighestSell;
                case BestBargainTypes.LowestBuy:
                    return LowestBuy;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Returns the extreme price
        /// </summary>
        /// <param name="sFunction">MIN/MAX</param>
        /// <param name="bid">true/false (i.e. buyer or seller, respectively)</param>
        /// <returns>0.0 or the extreme price</returns>
        internal double GetExtremePrice(string sFunction, bool bid)
        {
            double dExtreme = 0;
            Object obj = this.MarketTable.Compute(sFunction + "(price)", string.Format("bid = {0}", bid));
            if (!(obj is DBNull))
            {
                dExtreme = Convert.ToDouble(obj);
            }
            return dExtreme;
        }

        #region Context menu for a DataGridView

        private void GetContextMenuForDataGridView(ref MarketScanner.Common.BgPaintedDataGridView dgv, ref ContextMenuStrip cms)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (cms.Items.Count == dgv.ColumnCount)// Only add menuitems if not already there
                {
                    // If the context menu was filled previously, then set the previous column visibility. 
                    ToolStripMenuItem tsMenuItem = (ToolStripMenuItem)cms.Items[i];
                    dgv.Columns[i].Visible = tsMenuItem.Checked;
                }
                else
                {
                    ToolStripMenuItem tsMenuItem = new ToolStripMenuItem();
                    tsMenuItem.Text = dgv.Columns[i].HeaderText;
                    tsMenuItem.Name = dgv.Columns[i].Name;
                    tsMenuItem.Checked = dgv.Columns[i].Visible;
                    tsMenuItem.CheckOnClick = true;
                    cms.Items.Add(tsMenuItem);
                }
                // set the contextmenu for each column header.
                dgv.Columns[i].HeaderCell.ContextMenuStrip = cms;
            }
            // Set click event for the toolstripitems
            cms.ItemClicked += new ToolStripItemClickedEventHandler(cms_ItemClicked);
        }


        private static void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem tsMenuItem = (ToolStripMenuItem)e.ClickedItem;
            ContextMenuStrip cms = (ContextMenuStrip)sender;
            DataGridView dgv = (DataGridView)cms.SourceControl;
            // hide/show column
            // strangely i had to negate the checked property. But i guess its a matter of event flow.
            // That the checked prop hasn't been set to its new value at this point.
            if (dgv.Columns != null) dgv.Columns[tsMenuItem.Name].Visible = !tsMenuItem.Checked;
        }

        #endregion

    }



    /* enum to express what field to sort on */
    public enum MarketLogCompareField
    {
        Item,
        Region,
        Created
    }



    /* Comparer for sorting marketlogs  */
    /// <summary>
    /// The CompareClass provides the implementation of the IComparer inteface
    /// </summary>
    class MarketLogComparer : IComparer
    {
        #region Private Variables
        private MarketLogCompareField _sortBy = MarketLogCompareField.Item;
        #endregion

        #region Properties
        public MarketLogCompareField SortBy
        {
            get
            {
                return _sortBy;
            }
            set
            {
                _sortBy = value;
            }
        }
        #endregion

        #region Constructor

        public MarketLogComparer()
        {
            //default constructor
        }

        public MarketLogComparer(MarketLogCompareField pSortBy)
        {
            _sortBy = pSortBy;
        }

        #endregion

        #region Methods
        public Int32 Compare(Object pFirstObject, Object pObjectToCompare)
        {
            if (pFirstObject is MarketLog)
            {
                switch (this._sortBy)
                {
                    case MarketLogCompareField.Item:
                        return String.Compare(((MarketLog)pFirstObject).Item, ((MarketLog)pObjectToCompare).Item);
                    //break;
                    case MarketLogCompareField.Region:
                        return String.Compare(((MarketLog)pFirstObject).Region, ((MarketLog)pObjectToCompare).Region);
                    //break;
                    case MarketLogCompareField.Created:
                        return DateTime.Compare(((MarketLog)pFirstObject).Created, ((MarketLog)pObjectToCompare).Created);
                    //break;
                    default:
                        return 0;
                    //break;
                }
            }
            return 0;
        }

        #endregion

        #region IComparer Members
        /*
        int IComparer.Compare( object x, object y )
        {
            throw new Exception( "The method or operation is not implemented." );
        }
        */
        #endregion
    }


}