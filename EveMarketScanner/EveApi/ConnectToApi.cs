using System;
using System.Windows.Forms;

namespace MarketScanner.EveApi
{
    public partial class ConnectToApi : Form
    {
        #region properties

        private EveAccount eaCurAccount;

        internal EveAccount CurrentAccount
        {
            get { return eaCurAccount; }
            set { eaCurAccount = value; }
        }

        #endregion



        public ConnectToApi()
        {
            InitializeComponent();

            // Test
            CurrentAccount = Values.SavedEveAccount;
            textBox1.Text = CurrentAccount.AccountUserId.ToString();
            // ----
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            this.Dispose();
        }
    }
}