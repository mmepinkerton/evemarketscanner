using System;
using System.IO;

namespace MarketScanner.Common
{
    class FileHandler
    {
        readonly string _sAppDataPath = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData )
, Values.APP_TITLE );
        internal string AppDataPath
        {
            get { return _sAppDataPath; }
        }

        readonly string _sErrorLogPath;
        internal string ErrorLogPath
        {
            get { return _sErrorLogPath; }
        }

        public FileHandler()
        {
            CheckForAppPath();
            _sErrorLogPath = Path.Combine( _sAppDataPath, "EMS_error.log" );
        }

        private void CheckForAppPath()
        {
            // Create the the Eve market scanner directory if it doesn't exist
            if (!Directory.Exists( AppDataPath ))
            {
                Directory.CreateDirectory( AppDataPath );
            }
        }

        /// <summary>
        /// Writes errors to log file
        /// </summary>
        /// <param name="exception">exception to write</param>
        public void WriteErrorLog( Exception exception )
        {
            try
            {
                OperatingSystem os = Environment.OSVersion; 

                StreamWriter logWriter;
                if (File.Exists( ErrorLogPath ))
                {
                    logWriter = File.AppendText( ErrorLogPath );
                }
                else
                {
                    logWriter = File.CreateText( ErrorLogPath );
                }
                logWriter.WriteLine();
                logWriter.WriteLine( "------ " + DateTime.Now + " --------" );
                logWriter.WriteLine();
                logWriter.Write( "OS      : " );
                logWriter.WriteLine( os );
                logWriter.Write( "Platform: " );
                logWriter.WriteLine( os.Platform );
                logWriter.WriteLine();
                logWriter.WriteLine( "----------------------------------" );
                logWriter.WriteLine();
                logWriter.WriteLine( exception );
                logWriter.WriteLine();
                logWriter.WriteLine( "----------------------------------" );
                logWriter.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine( "Error in writing errorlog:" + e.Message );
            }
        }


    }
}
