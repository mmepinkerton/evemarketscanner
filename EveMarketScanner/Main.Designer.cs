namespace MarketScanner
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Main ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeSystemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbLoadLogs = new System.Windows.Forms.ToolStripButton();
            this.tsbToggleItemBrowser = new System.Windows.Forms.ToolStripButton();
            this.tsbViewWallet = new System.Windows.Forms.ToolStripButton();
            this.FSWatcher = new System.IO.FileSystemWatcher();
            this.cbRegionsL = new System.Windows.Forms.ComboBox();
            this.cbRegionsR = new System.Windows.Forms.ComboBox();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.lblRegions = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblItemsChanged = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLogFileStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.ItemTreeView = new MarketScanner.Common.MarketTreeView();
            this.cbBargainTypeR = new MarketScanner.Common.FlatComboBox();
            this.lblDateExportedR = new System.Windows.Forms.Label();
            this.lblDateExportedTextR = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBargainTypeL = new MarketScanner.Common.FlatComboBox();
            this.lblDateExportedL = new System.Windows.Forms.Label();
            this.lblDateExportedTextL = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSellersL = new MarketScanner.Common.BgPaintedDataGridView();
            this.dgvBuyersR = new MarketScanner.Common.BgPaintedDataGridView();
            this.dgvBuyersL = new MarketScanner.Common.BgPaintedDataGridView();
            this.dgvSellersR = new MarketScanner.Common.BgPaintedDataGridView();
            this.tbMinQuantity = new System.Windows.Forms.TextBox();
            this.cbMinSysSec = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource( this.components );
            this.ToolTipsInfo = new System.Windows.Forms.ToolTip( this.components );
            this.lblMinSysSec = new MarketScanner.Common.TransparentLabel();
            this.lblMinQuantity = new MarketScanner.Common.TransparentLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellersL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyersR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyersL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellersR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size( 982, 24 );
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.excludeSystemsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem} );
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size( 40, 20 );
            this.toolStripMenuItem1.Text = "File";
            // 
            // excludeSystemsToolStripMenuItem
            // 
            this.excludeSystemsToolStripMenuItem.Name = "excludeSystemsToolStripMenuItem";
            this.excludeSystemsToolStripMenuItem.Size = new System.Drawing.Size( 182, 22 );
            this.excludeSystemsToolStripMenuItem.Text = "Exclude systems";
            this.excludeSystemsToolStripMenuItem.Click += new System.EventHandler( this.excludeSystemsToolStripMenuItem_Click );
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::MarketScanner.Properties.Resources.OptionsIcon;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size( 182, 22 );
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler( this.optionsToolStripMenuItem_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 179, 6 );
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size( 182, 22 );
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem} );
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size( 45, 20 );
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::MarketScanner.Properties.Resources.AboutIcon;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size( 122, 22 );
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler( this.aboutToolStripMenuItem_Click_1 );
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadLogs,
            this.tsbToggleItemBrowser,
            this.tsbViewWallet} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 24 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size( 982, 25 );
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler( this.toolStrip1_ItemClicked );
            // 
            // tsbLoadLogs
            // 
            this.tsbLoadLogs.Image = global::MarketScanner.Properties.Resources.LoadLogs_16x16;
            this.tsbLoadLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadLogs.Name = "tsbLoadLogs";
            this.tsbLoadLogs.Size = new System.Drawing.Size( 121, 22 );
            this.tsbLoadLogs.Text = "Load Marketlogs";
            this.tsbLoadLogs.Click += new System.EventHandler( this.tsbLoadLogs_Click );
            // 
            // tsbToggleItemBrowser
            // 
            this.tsbToggleItemBrowser.Image = global::MarketScanner.Properties.Resources.toggle;
            this.tsbToggleItemBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToggleItemBrowser.Name = "tsbToggleItemBrowser";
            this.tsbToggleItemBrowser.Size = new System.Drawing.Size( 118, 22 );
            this.tsbToggleItemBrowser.Text = "Toggle Browser";
            this.tsbToggleItemBrowser.Click += new System.EventHandler( this.tsbToggleItemBrowser_Click );
            // 
            // tsbViewWallet
            // 
            this.tsbViewWallet.Enabled = false;
            this.tsbViewWallet.Image = ((System.Drawing.Image)(resources.GetObject( "tsbViewWallet.Image" )));
            this.tsbViewWallet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewWallet.Name = "tsbViewWallet";
            this.tsbViewWallet.Size = new System.Drawing.Size( 96, 22 );
            this.tsbViewWallet.Text = "View Wallet";
            this.tsbViewWallet.Visible = false;
            this.tsbViewWallet.Click += new System.EventHandler( this.toolStripButton1_Click );
            // 
            // FSWatcher
            // 
            this.FSWatcher.EnableRaisingEvents = true;
            this.FSWatcher.Filter = "*.txt";
            this.FSWatcher.SynchronizingObject = this;
            // 
            // cbRegionsL
            // 
            this.cbRegionsL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbRegionsL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegionsL.FormattingEnabled = true;
            this.cbRegionsL.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbRegionsL.Location = new System.Drawing.Point( 431, 53 );
            this.cbRegionsL.Name = "cbRegionsL";
            this.cbRegionsL.Size = new System.Drawing.Size( 155, 21 );
            this.cbRegionsL.TabIndex = 5;
            this.cbRegionsL.SelectedIndexChanged += new System.EventHandler( this.cbRegionsL_SelectedIndexChanged );
            // 
            // cbRegionsR
            // 
            this.cbRegionsR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbRegionsR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegionsR.FormattingEnabled = true;
            this.cbRegionsR.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbRegionsR.Location = new System.Drawing.Point( 824, 54 );
            this.cbRegionsR.Name = "cbRegionsR";
            this.cbRegionsR.Size = new System.Drawing.Size( 155, 21 );
            this.cbRegionsR.TabIndex = 6;
            this.cbRegionsR.SelectedIndexChanged += new System.EventHandler( this.cbRegionsR_SelectedIndexChanged );
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbItems.Location = new System.Drawing.Point( 40, 53 );
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size( 151, 21 );
            this.cbItems.TabIndex = 4;
            this.cbItems.SelectedIndexChanged += new System.EventHandler( this.cbItems_SelectedIndexChanged );
            // 
            // lblRegions
            // 
            this.lblRegions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRegions.AutoSize = true;
            this.lblRegions.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblRegions.Location = new System.Drawing.Point( 197, 57 );
            this.lblRegions.Name = "lblRegions";
            this.lblRegions.Size = new System.Drawing.Size( 68, 13 );
            this.lblRegions.TabIndex = 7;
            this.lblRegions.Text = "Regions ->";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point( 2, 56 );
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size( 32, 13 );
            this.lblItems.TabIndex = 7;
            this.lblItems.Text = "Items";
            // 
            // lblItemsChanged
            // 
            this.lblItemsChanged.AutoSize = true;
            this.lblItemsChanged.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblItemsChanged.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblItemsChanged.ForeColor = System.Drawing.Color.Green;
            this.lblItemsChanged.Location = new System.Drawing.Point( 157, 57 );
            this.lblItemsChanged.Margin = new System.Windows.Forms.Padding( 0 );
            this.lblItemsChanged.Name = "lblItemsChanged";
            this.lblItemsChanged.Size = new System.Drawing.Size( 11, 13 );
            this.lblItemsChanged.TabIndex = 8;
            this.lblItemsChanged.Text = "!";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripLogFileStatus} );
            this.statusStrip1.Location = new System.Drawing.Point( 0, 662 );
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size( 982, 22 );
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size( 100, 16 );
            this.toolStripProgressBar1.Step = 5;
            // 
            // toolStripLogFileStatus
            // 
            this.toolStripLogFileStatus.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripLogFileStatus.Name = "toolStripLogFileStatus";
            this.toolStripLogFileStatus.Size = new System.Drawing.Size( 0, 17 );
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point( 0, 80 );
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add( this.ItemTreeView );
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerMain.Panel2.Controls.Add( this.cbBargainTypeR );
            this.splitContainerMain.Panel2.Controls.Add( this.lblDateExportedR );
            this.splitContainerMain.Panel2.Controls.Add( this.lblDateExportedTextR );
            this.splitContainerMain.Panel2.Controls.Add( this.panel1 );
            this.splitContainerMain.Panel2.Controls.Add( this.cbBargainTypeL );
            this.splitContainerMain.Panel2.Controls.Add( this.lblDateExportedL );
            this.splitContainerMain.Panel2.Controls.Add( this.lblDateExportedTextL );
            this.splitContainerMain.Panel2.Controls.Add( this.panel2 );
            this.splitContainerMain.Panel2.Controls.Add( this.tableLayoutPanel1 );
            this.splitContainerMain.Size = new System.Drawing.Size( 982, 581 );
            this.splitContainerMain.SplitterDistance = 191;
            this.splitContainerMain.SplitterWidth = 2;
            this.splitContainerMain.TabIndex = 1003;
            this.splitContainerMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler( this.splitContainerMain_SplitterMoved );
            // 
            // ItemTreeView
            // 
            this.ItemTreeView.AllowDrop = true;
            this.ItemTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemTreeView.FullRowSelect = true;
            this.ItemTreeView.HideSelection = false;
            this.ItemTreeView.Indent = 19;
            this.ItemTreeView.Location = new System.Drawing.Point( 0, 0 );
            this.ItemTreeView.Name = "ItemTreeView";
            this.ItemTreeView.Size = new System.Drawing.Size( 191, 581 );
            this.ItemTreeView.TabIndex = 0;
            this.ItemTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.ItemTreeView_AfterSelect );
            // 
            // cbBargainTypeR
            // 
            this.cbBargainTypeR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBargainTypeR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbBargainTypeR.FormattingEnabled = true;
            this.cbBargainTypeR.Location = new System.Drawing.Point( 651, 0 );
            this.cbBargainTypeR.Name = "cbBargainTypeR";
            this.cbBargainTypeR.Size = new System.Drawing.Size( 135, 21 );
            this.cbBargainTypeR.TabIndex = 1024;
            this.ToolTipsInfo.SetToolTip( this.cbBargainTypeR, "dfgdfgdfg" );
            this.cbBargainTypeR.SelectedIndexChanged += new System.EventHandler( this.cbBargainTypeR_SelectedIndexChanged );
            // 
            // lblDateExportedR
            // 
            this.lblDateExportedR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateExportedR.AutoSize = true;
            this.lblDateExportedR.Location = new System.Drawing.Point( 584, 4 );
            this.lblDateExportedR.Name = "lblDateExportedR";
            this.lblDateExportedR.Size = new System.Drawing.Size( 61, 13 );
            this.lblDateExportedR.TabIndex = 1022;
            this.lblDateExportedR.Text = "10-28-2002";
            // 
            // lblDateExportedTextR
            // 
            this.lblDateExportedTextR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateExportedTextR.AutoSize = true;
            this.lblDateExportedTextR.Location = new System.Drawing.Point( 506, 4 );
            this.lblDateExportedTextR.Name = "lblDateExportedTextR";
            this.lblDateExportedTextR.Size = new System.Drawing.Size( 78, 13 );
            this.lblDateExportedTextR.TabIndex = 1023;
            this.lblDateExportedTextR.Text = "Date Exported:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point( 501, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 145, 21 );
            this.panel1.TabIndex = 1021;
            // 
            // cbBargainTypeL
            // 
            this.cbBargainTypeL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBargainTypeL.FormattingEnabled = true;
            this.cbBargainTypeL.Location = new System.Drawing.Point( 258, 0 );
            this.cbBargainTypeL.Name = "cbBargainTypeL";
            this.cbBargainTypeL.Size = new System.Drawing.Size( 135, 21 );
            this.cbBargainTypeL.TabIndex = 1020;
            this.ToolTipsInfo.SetToolTip( this.cbBargainTypeL, "This should be defined in the config\r\n-------------------------------------------" +
                    "---\r\nsdfsdfsdf\r\nsdfsdfsdf" );
            this.cbBargainTypeL.SelectedIndexChanged += new System.EventHandler( this.cbBargainTypeL_SelectedIndexChanged );
            // 
            // lblDateExportedL
            // 
            this.lblDateExportedL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDateExportedL.AutoSize = true;
            this.lblDateExportedL.Location = new System.Drawing.Point( 189, 4 );
            this.lblDateExportedL.Name = "lblDateExportedL";
            this.lblDateExportedL.Size = new System.Drawing.Size( 61, 13 );
            this.lblDateExportedL.TabIndex = 1019;
            this.lblDateExportedL.Text = "10-28-2002";
            // 
            // lblDateExportedTextL
            // 
            this.lblDateExportedTextL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDateExportedTextL.AutoSize = true;
            this.lblDateExportedTextL.Location = new System.Drawing.Point( 111, 4 );
            this.lblDateExportedTextL.Name = "lblDateExportedTextL";
            this.lblDateExportedTextL.Size = new System.Drawing.Size( 78, 13 );
            this.lblDateExportedTextL.TabIndex = 1018;
            this.lblDateExportedTextL.Text = "Date Exported:";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point( 106, 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 147, 21 );
            this.panel2.TabIndex = 1017;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            this.tableLayoutPanel1.Controls.Add( this.dgvSellersL, 0, 0 );
            this.tableLayoutPanel1.Controls.Add( this.dgvBuyersR, 1, 1 );
            this.tableLayoutPanel1.Controls.Add( this.dgvBuyersL, 0, 1 );
            this.tableLayoutPanel1.Controls.Add( this.dgvSellersR, 1, 0 );
            this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 16 );
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding( 0 );
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding( 2 );
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
            this.tableLayoutPanel1.Size = new System.Drawing.Size( 789, 566 );
            this.tableLayoutPanel1.TabIndex = 1007;
            // 
            // dgvSellersL
            // 
            this.dgvSellersL.AllowUserToOrderColumns = true;
            this.dgvSellersL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSellersL.BackgroundPadding = 10;
            this.dgvSellersL.BackgroundText = "Sellers";
            this.dgvSellersL.BackgroundTextFont = new System.Drawing.Font( "Arial", 20F );
            this.dgvSellersL.BackgroundTextPosition = MarketScanner.Common.BgPaintedDataGridView.TextPosition.TopLeft;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSellersL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSellersL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSellersL.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSellersL.Location = new System.Drawing.Point( 3, 4 );
            this.dgvSellersL.Margin = new System.Windows.Forms.Padding( 1, 2, 1, 1 );
            this.dgvSellersL.Name = "dgvSellersL";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSellersL.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSellersL.RowHeadersVisible = false;
            this.dgvSellersL.RowTemplate.ReadOnly = true;
            this.dgvSellersL.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSellersL.Size = new System.Drawing.Size( 390, 278 );
            this.dgvSellersL.TabIndex = 100;
            this.dgvSellersL.TabStop = false;
            // 
            // dgvBuyersR
            // 
            this.dgvBuyersR.AllowUserToOrderColumns = true;
            this.dgvBuyersR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBuyersR.BackgroundPadding = 10;
            this.dgvBuyersR.BackgroundText = "Buyers";
            this.dgvBuyersR.BackgroundTextFont = new System.Drawing.Font( "Arial", 20F );
            this.dgvBuyersR.BackgroundTextPosition = MarketScanner.Common.BgPaintedDataGridView.TextPosition.BottomRight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuyersR.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBuyersR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuyersR.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBuyersR.Location = new System.Drawing.Point( 395, 284 );
            this.dgvBuyersR.Margin = new System.Windows.Forms.Padding( 1 );
            this.dgvBuyersR.Name = "dgvBuyersR";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuyersR.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBuyersR.RowHeadersVisible = false;
            this.dgvBuyersR.RowTemplate.ReadOnly = true;
            this.dgvBuyersR.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuyersR.Size = new System.Drawing.Size( 391, 279 );
            this.dgvBuyersR.TabIndex = 400;
            this.dgvBuyersR.TabStop = false;
            // 
            // dgvBuyersL
            // 
            this.dgvBuyersL.AllowUserToOrderColumns = true;
            this.dgvBuyersL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBuyersL.BackgroundPadding = 10;
            this.dgvBuyersL.BackgroundText = "Buyers";
            this.dgvBuyersL.BackgroundTextFont = new System.Drawing.Font( "Arial", 20F );
            this.dgvBuyersL.BackgroundTextPosition = MarketScanner.Common.BgPaintedDataGridView.TextPosition.BottomLeft;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuyersL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBuyersL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuyersL.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBuyersL.Location = new System.Drawing.Point( 3, 284 );
            this.dgvBuyersL.Margin = new System.Windows.Forms.Padding( 1 );
            this.dgvBuyersL.Name = "dgvBuyersL";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuyersL.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBuyersL.RowHeadersVisible = false;
            this.dgvBuyersL.RowTemplate.ReadOnly = true;
            this.dgvBuyersL.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuyersL.Size = new System.Drawing.Size( 390, 279 );
            this.dgvBuyersL.TabIndex = 200;
            this.dgvBuyersL.TabStop = false;
            // 
            // dgvSellersR
            // 
            this.dgvSellersR.AllowUserToOrderColumns = true;
            this.dgvSellersR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSellersR.BackgroundPadding = 10;
            this.dgvSellersR.BackgroundText = "Sellers";
            this.dgvSellersR.BackgroundTextFont = new System.Drawing.Font( "Arial", 20F );
            this.dgvSellersR.BackgroundTextPosition = MarketScanner.Common.BgPaintedDataGridView.TextPosition.TopRight;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSellersR.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSellersR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSellersR.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSellersR.Location = new System.Drawing.Point( 395, 4 );
            this.dgvSellersR.Margin = new System.Windows.Forms.Padding( 1, 2, 1, 1 );
            this.dgvSellersR.Name = "dgvSellersR";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSellersR.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSellersR.RowHeadersVisible = false;
            this.dgvSellersR.RowTemplate.ReadOnly = true;
            this.dgvSellersR.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSellersR.Size = new System.Drawing.Size( 391, 278 );
            this.dgvSellersR.TabIndex = 300;
            this.dgvSellersR.TabStop = false;
            // 
            // tbMinQuantity
            // 
            this.tbMinQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMinQuantity.Location = new System.Drawing.Point( 701, 27 );
            this.tbMinQuantity.Name = "tbMinQuantity";
            this.tbMinQuantity.Size = new System.Drawing.Size( 100, 20 );
            this.tbMinQuantity.TabIndex = 1004;
            this.tbMinQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbMinSysSec
            // 
            this.cbMinSysSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMinSysSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinSysSec.FormattingEnabled = true;
            this.cbMinSysSec.Location = new System.Drawing.Point( 925, 27 );
            this.cbMinSysSec.MaxDropDownItems = 12;
            this.cbMinSysSec.Name = "cbMinSysSec";
            this.cbMinSysSec.Size = new System.Drawing.Size( 54, 21 );
            this.cbMinSysSec.TabIndex = 1006;
            // 
            // ToolTipsInfo
            // 
            this.ToolTipsInfo.AutomaticDelay = 30000;
            this.ToolTipsInfo.AutoPopDelay = 300000;
            this.ToolTipsInfo.InitialDelay = 3000;
            this.ToolTipsInfo.IsBalloon = true;
            this.ToolTipsInfo.ReshowDelay = 6000;
            this.ToolTipsInfo.ShowAlways = true;
            this.ToolTipsInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTipsInfo.ToolTipTitle = "Information";
            // 
            // lblMinSysSec
            // 
            this.lblMinSysSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinSysSec.Location = new System.Drawing.Point( 815, 31 );
            this.lblMinSysSec.Name = "lblMinSysSec";
            this.lblMinSysSec.Size = new System.Drawing.Size( 107, 13 );
            this.lblMinSysSec.TabIndex = 1007;
            this.lblMinSysSec.TabStop = false;
            this.lblMinSysSec.Text = "Min. System security";
            // 
            // lblMinQuantity
            // 
            this.lblMinQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinQuantity.Location = new System.Drawing.Point( 629, 31 );
            this.lblMinQuantity.Name = "lblMinQuantity";
            this.lblMinQuantity.Size = new System.Drawing.Size( 68, 13 );
            this.lblMinQuantity.TabIndex = 1005;
            this.lblMinQuantity.TabStop = false;
            this.lblMinQuantity.Text = "Min. Quantity";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 982, 684 );
            this.Controls.Add( this.cbMinSysSec );
            this.Controls.Add( this.lblMinSysSec );
            this.Controls.Add( this.lblMinQuantity );
            this.Controls.Add( this.tbMinQuantity );
            this.Controls.Add( this.toolStrip1 );
            this.Controls.Add( this.splitContainerMain );
            this.Controls.Add( this.lblItemsChanged );
            this.Controls.Add( this.lblItems );
            this.Controls.Add( this.lblRegions );
            this.Controls.Add( this.cbItems );
            this.Controls.Add( this.cbRegionsR );
            this.Controls.Add( this.cbRegionsL );
            this.Controls.Add( this.menuStrip1 );
            this.Controls.Add( this.statusStrip1 );
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "APP_TITLE";
            this.Load += new System.EventHandler( this.Main_Load );
            this.menuStrip1.ResumeLayout( false );
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).EndInit();
            this.statusStrip1.ResumeLayout( false );
            this.statusStrip1.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout( false );
            this.splitContainerMain.Panel2.ResumeLayout( false );
            this.splitContainerMain.Panel2.PerformLayout();
            this.splitContainerMain.ResumeLayout( false );
            this.tableLayoutPanel1.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellersL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyersR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyersL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellersR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.ComboBox cbRegionsR;
        private System.Windows.Forms.ComboBox cbRegionsL;
        private System.Windows.Forms.ToolStripButton tsbLoadLogs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblRegions;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblItemsChanged;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton tsbViewWallet;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private MarketScanner.Common.MarketTreeView ItemTreeView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MarketScanner.Common.BgPaintedDataGridView dgvSellersL;
        private MarketScanner.Common.BgPaintedDataGridView dgvSellersR;
        private MarketScanner.Common.BgPaintedDataGridView dgvBuyersR;
        private MarketScanner.Common.BgPaintedDataGridView dgvBuyersL;
        private MarketScanner.Common.FlatComboBox cbBargainTypeL;
        private System.Windows.Forms.Label lblDateExportedL;
        private System.Windows.Forms.Label lblDateExportedTextL;
        private System.Windows.Forms.Panel panel2;
        private MarketScanner.Common.FlatComboBox cbBargainTypeR;
        private System.Windows.Forms.Label lblDateExportedR;
        private System.Windows.Forms.Label lblDateExportedTextR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLogFileStatus;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ComboBox cbMinSysSec;
        private MarketScanner.Common.TransparentLabel lblMinSysSec;
        private MarketScanner.Common.TransparentLabel lblMinQuantity;
        private System.Windows.Forms.TextBox tbMinQuantity;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton tsbToggleItemBrowser;
        private System.Windows.Forms.ToolTip ToolTipsInfo;
        private System.Windows.Forms.ToolStripMenuItem excludeSystemsToolStripMenuItem;
        internal System.IO.FileSystemWatcher FSWatcher;

        




    }
}

