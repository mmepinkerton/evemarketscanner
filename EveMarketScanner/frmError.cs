using System;
using System.Windows.Forms;
using MarketScanner.Common;

namespace MarketScanner
{
    public partial class frmError : Form
    {
        public string ErrorMessage
        {
            set { tbError.Text = value; }
        }

        public frmError()
        {
            InitializeComponent();

            // Force grip style shown
            this.SizeGripStyle = SizeGripStyle.Show;

            // Set icon
            this.Icon = Values.icoAppIcon;

            MarketScanner.Common.FileHandler filehandler = new FileHandler();
            string messageForUser = string.Format("An unhandled error has occurred. The error is shown in the text box below and also written to the error log at \"{0}\"", filehandler.ErrorLogPath);
            label1.Text = messageForUser;

        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
