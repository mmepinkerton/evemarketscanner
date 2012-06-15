namespace MarketScanner
{
    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butOptionsSave = new System.Windows.Forms.Button();
            this.butOptionsCancel = new System.Windows.Forms.Button();
            this.grpbPaths = new System.Windows.Forms.GroupBox();
            this.butOptionsSetDefault = new System.Windows.Forms.Button();
            this.butOptionsBrowse = new System.Windows.Forms.Button();
            this.tbMarketlogsPath = new System.Windows.Forms.TextBox();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grpbStartup = new System.Windows.Forms.GroupBox();
            this.cbReadConquerableStationsFromApi = new System.Windows.Forms.CheckBox();
            this.cbLoadLogsOnStart = new System.Windows.Forms.CheckBox();
            this.cbLogFilterSet = new System.Windows.Forms.CheckBox();
            this.dtpLogDateFilter = new System.Windows.Forms.DateTimePicker();
            this.grpbFilter = new System.Windows.Forms.GroupBox();
            this.cbShowAllAvailableMarketItemsInTreeView = new System.Windows.Forms.CheckBox();
            this.cbIgnoreExpiredOrders = new System.Windows.Forms.CheckBox();
            this.grpbPaths.SuspendLayout();
            this.grpbStartup.SuspendLayout();
            this.grpbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOptionsSave
            // 
            this.butOptionsSave.Location = new System.Drawing.Point( 372, 377 );
            this.butOptionsSave.Name = "butOptionsSave";
            this.butOptionsSave.Size = new System.Drawing.Size( 75, 23 );
            this.butOptionsSave.TabIndex = 0;
            this.butOptionsSave.Text = "Save";
            this.butOptionsSave.UseVisualStyleBackColor = true;
            this.butOptionsSave.Click += new System.EventHandler( this.butOptionsSave_Click );
            // 
            // butOptionsCancel
            // 
            this.butOptionsCancel.Location = new System.Drawing.Point( 455, 377 );
            this.butOptionsCancel.Name = "butOptionsCancel";
            this.butOptionsCancel.Size = new System.Drawing.Size( 75, 23 );
            this.butOptionsCancel.TabIndex = 0;
            this.butOptionsCancel.Text = "Cancel";
            this.butOptionsCancel.UseVisualStyleBackColor = true;
            this.butOptionsCancel.Click += new System.EventHandler( this.butOptionsCancel_Click );
            // 
            // grpbPaths
            // 
            this.grpbPaths.Controls.Add( this.butOptionsSetDefault );
            this.grpbPaths.Controls.Add( this.butOptionsBrowse );
            this.grpbPaths.Controls.Add( this.tbMarketlogsPath );
            this.grpbPaths.Controls.Add( this.lblLogPath );
            this.grpbPaths.Location = new System.Drawing.Point( 12, 12 );
            this.grpbPaths.Name = "grpbPaths";
            this.grpbPaths.Size = new System.Drawing.Size( 518, 93 );
            this.grpbPaths.TabIndex = 1;
            this.grpbPaths.TabStop = false;
            this.grpbPaths.Text = "Paths";
            // 
            // butOptionsSetDefault
            // 
            this.butOptionsSetDefault.Location = new System.Drawing.Point( 349, 56 );
            this.butOptionsSetDefault.Name = "butOptionsSetDefault";
            this.butOptionsSetDefault.Size = new System.Drawing.Size( 75, 23 );
            this.butOptionsSetDefault.TabIndex = 3;
            this.butOptionsSetDefault.Text = "Default";
            this.butOptionsSetDefault.UseVisualStyleBackColor = true;
            this.butOptionsSetDefault.Click += new System.EventHandler( this.butOptionsSetDefault_Click );
            // 
            // butOptionsBrowse
            // 
            this.butOptionsBrowse.Location = new System.Drawing.Point( 430, 56 );
            this.butOptionsBrowse.Name = "butOptionsBrowse";
            this.butOptionsBrowse.Size = new System.Drawing.Size( 75, 23 );
            this.butOptionsBrowse.TabIndex = 2;
            this.butOptionsBrowse.Text = "Browse";
            this.butOptionsBrowse.UseVisualStyleBackColor = true;
            this.butOptionsBrowse.Click += new System.EventHandler( this.butOptionsBrowse_Click );
            // 
            // tbMarketlogsPath
            // 
            this.tbMarketlogsPath.Location = new System.Drawing.Point( 75, 23 );
            this.tbMarketlogsPath.Margin = new System.Windows.Forms.Padding( 10 );
            this.tbMarketlogsPath.Name = "tbMarketlogsPath";
            this.tbMarketlogsPath.Size = new System.Drawing.Size( 430, 20 );
            this.tbMarketlogsPath.TabIndex = 1;
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Location = new System.Drawing.Point( 13, 26 );
            this.lblLogPath.Margin = new System.Windows.Forms.Padding( 10 );
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size( 62, 13 );
            this.lblLogPath.TabIndex = 0;
            this.lblLogPath.Text = "Marketlogs:";
            // 
            // grpbStartup
            // 
            this.grpbStartup.Controls.Add( this.cbReadConquerableStationsFromApi );
            this.grpbStartup.Controls.Add( this.cbLoadLogsOnStart );
            this.grpbStartup.Location = new System.Drawing.Point( 12, 112 );
            this.grpbStartup.Name = "grpbStartup";
            this.grpbStartup.Size = new System.Drawing.Size( 267, 259 );
            this.grpbStartup.TabIndex = 2;
            this.grpbStartup.TabStop = false;
            this.grpbStartup.Text = "Startup";
            // 
            // cbReadConquerableStationsFromApi
            // 
            this.cbReadConquerableStationsFromApi.AutoSize = true;
            this.cbReadConquerableStationsFromApi.Location = new System.Drawing.Point( 6, 38 );
            this.cbReadConquerableStationsFromApi.Name = "cbReadConquerableStationsFromApi";
            this.cbReadConquerableStationsFromApi.Size = new System.Drawing.Size( 180, 17 );
            this.cbReadConquerableStationsFromApi.TabIndex = 4;
            this.cbReadConquerableStationsFromApi.Text = "Get outpost names from Eve API";
            this.cbReadConquerableStationsFromApi.UseVisualStyleBackColor = true;
            // 
            // cbLoadLogsOnStart
            // 
            this.cbLoadLogsOnStart.AutoSize = true;
            this.cbLoadLogsOnStart.Location = new System.Drawing.Point( 6, 19 );
            this.cbLoadLogsOnStart.Name = "cbLoadLogsOnStart";
            this.cbLoadLogsOnStart.Size = new System.Drawing.Size( 107, 17 );
            this.cbLoadLogsOnStart.TabIndex = 0;
            this.cbLoadLogsOnStart.Text = "Load market logs";
            this.cbLoadLogsOnStart.UseVisualStyleBackColor = true;
            // 
            // cbLogFilterSet
            // 
            this.cbLogFilterSet.AutoSize = true;
            this.cbLogFilterSet.Location = new System.Drawing.Point( 6, 19 );
            this.cbLogFilterSet.Name = "cbLogFilterSet";
            this.cbLogFilterSet.Size = new System.Drawing.Size( 201, 17 );
            this.cbLogFilterSet.TabIndex = 3;
            this.cbLogFilterSet.Text = "Only show logs from this date forward";
            this.cbLogFilterSet.UseVisualStyleBackColor = true;
            // 
            // dtpLogDateFilter
            // 
            this.dtpLogDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLogDateFilter.Location = new System.Drawing.Point( 6, 38 );
            this.dtpLogDateFilter.Name = "dtpLogDateFilter";
            this.dtpLogDateFilter.Size = new System.Drawing.Size( 194, 20 );
            this.dtpLogDateFilter.TabIndex = 1;
            // 
            // grpbFilter
            // 
            this.grpbFilter.Controls.Add( this.cbIgnoreExpiredOrders );
            this.grpbFilter.Controls.Add( this.cbShowAllAvailableMarketItemsInTreeView );
            this.grpbFilter.Controls.Add( this.cbLogFilterSet );
            this.grpbFilter.Controls.Add( this.dtpLogDateFilter );
            this.grpbFilter.Location = new System.Drawing.Point( 285, 112 );
            this.grpbFilter.Name = "grpbFilter";
            this.grpbFilter.Size = new System.Drawing.Size( 245, 259 );
            this.grpbFilter.TabIndex = 3;
            this.grpbFilter.TabStop = false;
            this.grpbFilter.Text = "Filters";
            // 
            // cbShowAllAvailableMarketItemsInTreeView
            // 
            this.cbShowAllAvailableMarketItemsInTreeView.AutoSize = true;
            this.cbShowAllAvailableMarketItemsInTreeView.Location = new System.Drawing.Point( 6, 64 );
            this.cbShowAllAvailableMarketItemsInTreeView.Name = "cbShowAllAvailableMarketItemsInTreeView";
            this.cbShowAllAvailableMarketItemsInTreeView.Size = new System.Drawing.Size( 224, 17 );
            this.cbShowAllAvailableMarketItemsInTreeView.TabIndex = 4;
            this.cbShowAllAvailableMarketItemsInTreeView.Text = "Show all available market items in browser";
            this.cbShowAllAvailableMarketItemsInTreeView.UseVisualStyleBackColor = true;
            // 
            // cbIgnoreExpiredOrders
            // 
            this.cbIgnoreExpiredOrders.AutoSize = true;
            this.cbIgnoreExpiredOrders.Location = new System.Drawing.Point( 6, 87 );
            this.cbIgnoreExpiredOrders.Name = "cbIgnoreExpiredOrders";
            this.cbIgnoreExpiredOrders.Size = new System.Drawing.Size( 125, 17 );
            this.cbIgnoreExpiredOrders.TabIndex = 4;
            this.cbIgnoreExpiredOrders.Text = "Ignore expired orders";
            this.cbIgnoreExpiredOrders.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 542, 413 );
            this.Controls.Add( this.grpbFilter );
            this.Controls.Add( this.grpbStartup );
            this.Controls.Add( this.grpbPaths );
            this.Controls.Add( this.butOptionsCancel );
            this.Controls.Add( this.butOptionsSave );
            this.Name = "FrmOptions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.TopMost = true;
            this.grpbPaths.ResumeLayout( false );
            this.grpbPaths.PerformLayout();
            this.grpbStartup.ResumeLayout( false );
            this.grpbStartup.PerformLayout();
            this.grpbFilter.ResumeLayout( false );
            this.grpbFilter.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button butOptionsSave;
        private System.Windows.Forms.Button butOptionsCancel;
        private System.Windows.Forms.GroupBox grpbPaths;
        private System.Windows.Forms.TextBox tbMarketlogsPath;
        private System.Windows.Forms.Label lblLogPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button butOptionsBrowse;
        private System.Windows.Forms.Button butOptionsSetDefault;
        private System.Windows.Forms.GroupBox grpbStartup;
        private System.Windows.Forms.CheckBox cbLoadLogsOnStart;
        private System.Windows.Forms.DateTimePicker dtpLogDateFilter;
        private System.Windows.Forms.CheckBox cbLogFilterSet;
        private System.Windows.Forms.CheckBox cbReadConquerableStationsFromApi;
        private System.Windows.Forms.GroupBox grpbFilter;
        private System.Windows.Forms.CheckBox cbShowAllAvailableMarketItemsInTreeView;
        private System.Windows.Forms.CheckBox cbIgnoreExpiredOrders;
    }
}