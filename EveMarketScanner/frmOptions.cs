using System;
using System.Windows.Forms;

namespace MarketScanner
{
    public partial class FrmOptions : Form
    {
        private bool bNeedLogReload = false;

        public FrmOptions()
        {
            InitializeComponent();
            //MessageBox.Show( Properties.Settings.Default.MyMarketLogPath );
            this.Icon = Values.icoAppIcon;

            this.tbMarketlogsPath.Text = Values.MarketLogPath;
            this.cbLoadLogsOnStart.Checked = Values.LoadLogsOnStartup;
            this.cbLogFilterSet.Checked = Values.IsLogsDateFilterSet;
            this.dtpLogDateFilter.Value = Values.LogsDateFilter;
            this.cbReadConquerableStationsFromApi.Checked = Values.ReadConquerableStationsFromApi;
            this.cbShowAllAvailableMarketItemsInTreeView.Checked = Values.ShowAllAvailableMarketItemsInTreeView;
            this.cbIgnoreExpiredOrders.Checked = Values.IgnoreExpiredOrders;
        }

        private void butOptionsCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOptionsSave_Click(object sender, EventArgs e)
        {
            // Validate app settings, save and close.
            // Validate Path
            string sPath = this.tbMarketlogsPath.Text;
            if (Values.IsPathValid(sPath))
            {
                Values.MarketLogPath = sPath;
                // Reload path for event listening
                ((Main)this.Owner).FSWatcherLogs.Path = Values.MarketLogPath;
                bNeedLogReload = true;
            }
            else
            {
                MessageBox.Show("The path (" + sPath + ") is not valid!", Values.MSG_ERROR);
                return;
            }
            // save other options
            Values.LoadLogsOnStartup = this.cbLoadLogsOnStart.Checked;
            Values.ReadConquerableStationsFromApi = this.cbReadConquerableStationsFromApi.Checked;
            // refresh stations if this is checked
            if (this.cbReadConquerableStationsFromApi.Checked)
            {
                Values.slStationNames = DataHandler.GetStationNames(Values.dtStationNames, Values.ReadConquerableStationsFromApi);
            }
            // if a filter option has changed, then refresh logs and regions
            if (Values.LogsDateFilter != this.dtpLogDateFilter.Value.Date ||
                Values.IsLogsDateFilterSet != this.cbLogFilterSet.Checked ||
                Values.ShowAllAvailableMarketItemsInTreeView != this.cbShowAllAvailableMarketItemsInTreeView.Checked ||
                Values.IgnoreExpiredOrders != this.cbIgnoreExpiredOrders.Checked)
            {
                Values.IsLogsDateFilterSet = this.cbLogFilterSet.Checked;
                Values.LogsDateFilter = this.dtpLogDateFilter.Value.Date;
                Values.ShowAllAvailableMarketItemsInTreeView = this.cbShowAllAvailableMarketItemsInTreeView.Checked;
                Values.IgnoreExpiredOrders = this.cbIgnoreExpiredOrders.Checked;
                bNeedLogReload = true;
            }

            // reload logs if necessary
            if (bNeedLogReload)
            {
                ReloadLogs();
            }

            //Exit
            this.Close();
        }

        private void ReloadLogs()
        {
            if (Values.UseCacheReader)
            {
                ((Main)this.Owner).ReloadMarketLogsFromCache();
            }
            else
            {
                ((Main)this.Owner).ReloadMarketLogs();

            }
            ((Main)this.Owner).RefreshRegions();
        }

        private void butOptionsBrowse_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                Values.MarketLogPath = this.tbMarketlogsPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void butOptionsSetDefault_Click(object sender, EventArgs e)
        {
            Values.MarketLogPath = this.tbMarketlogsPath.Text = Values.sDefaultMarketLogPath;
        }

    }
}