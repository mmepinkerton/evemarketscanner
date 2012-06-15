using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MarketScanner
{
    /* Class for parsing of Eve Online Logs */
    class Parser
    {
        // method to convert filename timestamp of marketlog to a datetime
        // Accepts this format: "2007.05.04 120923"
        internal static DateTime parseTimestamp( string s )
        {
            string[] sParts = s.Split( ' ' );
            string[] sDateParts = sParts[0].Split( '.' );
            int[] iTimeParts = new int[3];
            for (int i = 0 ; i <= 2 ; ++i)
            {
                iTimeParts[i] = int.Parse( sParts[1].Substring( i * 2, 2 ) );
            }
            if (sDateParts.Length == 3 && iTimeParts.Length == 3)
            {
                DateTime dt = new DateTime( int.Parse( sDateParts[0] ), int.Parse( sDateParts[1] ), int.Parse( sDateParts[2] ), iTimeParts[0], iTimeParts[1], iTimeParts[2] );
                return dt;
            }
            else
            {
                throw new FormatException();
            }

        }

        internal MarketLog parseMarketLog( FileInfo fi, ref Dictionary<int, string> dRegionNames )
        {
            String sFileName = fi.Name.Substring( 0, fi.Name.LastIndexOf( '.' ) ).ToString();
            string sDateCreated = string.Empty;
            string sItem = string.Empty;
            string sRegion = string.Empty;
            int iLastHyphen = sFileName.LastIndexOf( '-' );
            int iFirstHyphen = sFileName.IndexOf( '-' );

            if (iLastHyphen != -1 && iFirstHyphen != -1 && !(iLastHyphen == iFirstHyphen))
            {
                sDateCreated = sFileName.Substring( iLastHyphen + 1, sFileName.Length - iLastHyphen - 1 ).Trim();
                sItem = sFileName.Substring( iFirstHyphen + 1, iLastHyphen - iFirstHyphen - 1 ).Trim();
                sRegion = sFileName.Substring( 0, iFirstHyphen ).Trim();

                // Check for regions with hyphens
                if (!dRegionNames.ContainsValue( sRegion ))
                {
                    string[] saFileNameParts = sFileName.Split( '-' );
                    sRegion = string.Format( "{0}-{1}", saFileNameParts );
                    // If error give light error message and return null, but continue parsing.
                    if (!dRegionNames.ContainsValue( sRegion )) //throw new Exception("Error parsing file: " + sFileName);
                    {
                        MarketScanner.Main.LightErrorMessage += string.Format( "Error parsing file:{1}{0}", Environment.NewLine, fi.Name );
                        return null;
                    }
                    // Fix the item
                    sItem = sItem.Substring( sItem.IndexOf( '-' ) + 1 ).Trim();
                }

                MarketLog oMarketLog = new MarketLog();
                oMarketLog.Created = parseTimestamp( sDateCreated );
                oMarketLog.Item = sItem;
                oMarketLog.Region = sRegion;
                oMarketLog.FileName = fi.Name;
                oMarketLog.FilePath = fi.FullName;

                return oMarketLog;
            }
            else
            {
                return null;
            }
        }

    }
}
