using System;
using System.Threading;
using System.Windows.Forms;
using MarketScanner.Common;

namespace MarketScanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Catch all unhandled exceptions
            Application.ThreadException += new ThreadExceptionEventHandler( ThreadExceptionHandler );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Main() );
        }

        // Global exeption handlers
        private static void ThreadExceptionHandler( object sender, ThreadExceptionEventArgs args )
        {
            try
            {
                // Write to error log
                MarketScanner.Common.FileHandler filehandler = new FileHandler();
                filehandler.WriteErrorLog( args.Exception );

                frmError errWindow = new frmError();
                errWindow.StartPosition = FormStartPosition.CenterParent;
                errWindow.ErrorMessage = args.Exception.ToString();
                errWindow.Show();
            }
            catch
            {
            }
        }
    }
}