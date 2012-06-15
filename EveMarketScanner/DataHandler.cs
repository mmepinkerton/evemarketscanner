using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using MarketScanner.Common;
using MarketScanner.EveApi;


namespace MarketScanner
{
    class DataHandler
    {

        internal static void CreateRelation( ref DataSet ds, string sParent, string sParentCol, string sChild, string sChildCol )
        {
            // Get the DataColumn objects from two DataTable objects 
            DataColumn parentColumn = ds.Tables[sParent].Columns[sParentCol];
            DataColumn childColumn = ds.Tables[sChild].Columns[sChildCol];
            // Create DataRelation.
            DataRelation relParentChild = new DataRelation( sParent + "-" + sChild, parentColumn, childColumn );
            // Add the relation to the DataSet.
            ds.Relations.Add( relParentChild );
        }

        internal static DataTable CreateMarketLogsListTable()
        {
            DataTable marketLogsList = new DataTable( "MarketLogsList" );

            marketLogsList.Columns.Add( "region", Type.GetType( "System.String" ) );
            marketLogsList.Columns.Add( "item", Type.GetType( "System.String" ) );
            marketLogsList.Columns.Add( "created", Type.GetType( "System.DateTime" ) );
            marketLogsList.Columns.Add( "filename", Type.GetType( "System.String" ) );
            marketLogsList.Columns.Add( "filepath", Type.GetType( "System.String" ) );
            // Return the new DataTable.
            return marketLogsList;
        }


        internal static DataTable CreateMarketLogEntriesTable()
        {
            DataTable marketLogEntries = new DataTable( "MarketLogEntries" );

            marketLogEntries.Columns.Add( "price", Type.GetType( "System.Double" ) );
            marketLogEntries.Columns.Add( "volRemaining", Type.GetType( "System.Double" ) );
            marketLogEntries.Columns.Add( "typeID", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "range", Type.GetType( "System.String" ) );
            marketLogEntries.Columns.Add( "orderID", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "volEntered", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "minVolume", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "bid", Type.GetType( "System.Boolean" ) );
            marketLogEntries.Columns.Add( "issued", Type.GetType( "System.DateTime" ) );
            marketLogEntries.Columns.Add( "duration", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "stationID", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "regionID", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "solarSystemID", Type.GetType( "System.Int32" ) );
            marketLogEntries.Columns.Add( "jumps", Type.GetType( "System.String" ) );
            marketLogEntries.Columns.Add( "stationName", Type.GetType( "System.String" ) );
            marketLogEntries.Columns.Add( "expires", Type.GetType( "System.String" ) );
            marketLogEntries.Columns.Add( "Security", Type.GetType( "System.Double" ) );
            marketLogEntries.Columns.Add( "corporationName", Type.GetType( "System.String" ) );

            // Return the new DataTable.
            return marketLogEntries;
        }

        internal static DataTable CreateSellersEntriesTable()
        {
            DataTable dtSellersEntries = new DataTable( "SellersEntries" );

            dtSellersEntries.Columns.Add( "Jumps", Type.GetType( "System.Int32" ) );
            dtSellersEntries.Columns.Add( "Quantity", Type.GetType( "System.Int32" ) );
            dtSellersEntries.Columns.Add( "Price", Type.GetType( "System.Double" ) );
            dtSellersEntries.Columns.Add( "Location", Type.GetType( "System.String" ) );
            dtSellersEntries.Columns.Add( "Expires", Type.GetType( "System.DateTime" ) );

            // Return the new DataTable.
            return dtSellersEntries;
        }

        internal static DataTable CreateBuyersEntriesTable()
        {
            DataTable dtBuyersEntries = new DataTable( "BuyersEntries" );

            dtBuyersEntries.Columns.Add( "Jumps", Type.GetType( "System.Int32" ) );
            dtBuyersEntries.Columns.Add( "Quantity", Type.GetType( "System.Int32" ) );
            dtBuyersEntries.Columns.Add( "Price", Type.GetType( "System.Double" ) );
            dtBuyersEntries.Columns.Add( "Location", Type.GetType( "System.String" ) );
            dtBuyersEntries.Columns.Add( "range", Type.GetType( "System.String" ) );
            dtBuyersEntries.Columns.Add( "minVolume", Type.GetType( "System.Int32" ) );
            dtBuyersEntries.Columns.Add( "Expires", Type.GetType( "System.DateTime" ) );

            // Return the new DataTable.
            return dtBuyersEntries;
        }

        internal static MarketLog DataRowToMarketLog( DataRow dr )
        {
            MarketLog ml = new MarketLog();
            ml.Region = (string)dr["region"];
            ml.Item = (string)dr["item"];
            ml.Created = (DateTime)dr["created"];
            ml.FileName = (string)dr["filename"];
            ml.FilePath = (string)dr["filepath"];
            return ml;
        }

        internal static DataRow MarketLogToDataRow( MarketLog ml, DataTable dtSource )
        {
            DataRow dr = dtSource.NewRow();
            dr["region"] = ml.Region;
            dr["item"] = ml.Item;
            dr["created"] = ml.Created;
            dr["filename"] = ml.FileName;
            dr["filepath"] = ml.FilePath;
            return dr;
        }

        public static string ReplaceEscapeChars( string str )
        {
            //If the string is null
            if (str == null)
                return str;

            //If the string is empty
            if (str == "")
                return str;

            //Replaces single quote (') with two (2) single quotes ('')
            //solves the problem of inserting, updating or selecting a text with single quote (')
            //i.e.: Cox's Bazar, World's economy etc.
            str = str.Replace( "'", "''" );
            return str;
        }

        public static DataTable DataTableFromCompressedXmlFile( string sPath )
        {
            DataSet dsXml = new DataSet();
            if (File.Exists( sPath ))
            {
                using (FileStream fs = new FileStream( sPath, FileMode.Open, FileAccess.Read ))
                using (GZipStream zs = new GZipStream( fs, CompressionMode.Decompress ))
                {
                    try
                    {
                        dsXml.ReadXml( zs, XmlReadMode.Auto );
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        throw ex;
                        // GeneralExeptionHandling("The resource could not be loaded!", ex)
                    }
                }
                DataTable dt = dsXml.Tables[0];
                return dt;
            }
            else
            {
                throw new Exception( "The compressed xml file doesn't exist: " + sPath );
            }
        }

        public static XmlDocument FromCompressedXmlFile( string sPath )
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists( sPath ))
            {
                using (FileStream fs = new FileStream( sPath, FileMode.Open, FileAccess.Read ))
                using (GZipStream zs = new GZipStream( fs, CompressionMode.Decompress ))
                {
                    try
                    {
                        xmlDoc.Load( zs );
                        // dsXml.ReadXml( zs, XmlReadMode.Auto );
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        throw ex;
                        // GeneralExeptionHandling("The resource could not be loaded!", ex)
                    }
                }
                return xmlDoc;
            }
            else
            {
                throw new Exception( "The compressed xml file doesn't exist: " + sPath );
            }
        }

        /// <summary>
        /// Reads station names from datatable and optionally Outpost names from EveApi
        /// </summary>
        /// <param name="dtNames">Source datatable</param>
        /// <param name="readConquerableStationsFromApi">Wheter to load outposts</param>
        /// <returns></returns>
        internal static SortedList<long, Tuple<string, string>> GetStationNames( DataTable dtNames, bool readConquerableStationsFromApi )
        {
            SortedList<long, Tuple<string, string>> sl = new SortedList<long, Tuple<string, string>>();

            // Get station names from datatable
            foreach (DataRow dr in dtNames.Rows)
            {
                sl.Add( int.Parse( dr["stationID"].ToString() ), new Tuple<string, string>( dr["stationName"].ToString().Trim(), dr["corporationName"].ToString().Trim() ) );
            }

            // Load outposts from eveApi too
            if (readConquerableStationsFromApi)
            {
                XmlDocument xmlDoc = null;
                bool outpostsLoaded = false;
                try
                {
                    // First try to load outposts from eve api
                    EveApiRequest apiRequest = new EveApiRequest();
                    xmlDoc = EveApiRequest.FetchXmlData( Values.APIBASE + Values.sApiConquerableStationListUrl );
                }
                catch (Exception e)
                {
                    Main.LightErrorMessage += e.Message + "\r\n";
                    Main.LightErrorMessage += "- Outpost names could not be loaded.\r\n\r\n";
                    Main.IsAppOffline = true;
                    // Try to load cached version if eve api fails
                    try { outpostsLoaded = ReadCachedOutposts( ref xmlDoc ); }
                    catch (FileNotFoundException)
                    {
                        Main.LightErrorMessage += "- Local outpost cache not found either.\r\n Optionally disable option to fetch conquerable station names on program startup in File -> Options.\r\n";
                    }
                    if (outpostsLoaded)
                    {
                        Main.LightErrorMessage += "Loading alternative cached outpost list.\r\n";
                        XmlNodeList nodesRetrievalTime = xmlDoc.SelectNodes( "//currentTime" );
                        if (nodesRetrievalTime != null && nodesRetrievalTime.Count > 0)
                        {
                            Main.LightErrorMessage += "- Note that this file might be outdated.\r\n";
                            Main.LightErrorMessage += string.Format( "- Time of retrival: {0}\r\n", nodesRetrievalTime[0].InnerText );
                        }
                        else
                        {
                            Main.LightErrorMessage += "- The cached version seems malformed. Outpost names not available.\r\n";
                        }
                    }
                }
                if (xmlDoc != null && xmlDoc.HasChildNodes)
                {
                    XmlNodeList nodes = xmlDoc.SelectNodes( "//result/rowset/row" ); // Get only the relevant rows
                    if (nodes != null && nodes.Count > 0)
                    {
                        foreach (XmlNode node in nodes)
                        {
                            long stationID = long.Parse( node.Attributes["stationID"].InnerText );
                            // some stations are Conquerable and therefore need to have the name updated from the outpost list
                            // So we have to check if its already in the list
                            if (!sl.ContainsKey( stationID )) // Add the new outpost
                            {
                                sl.Add( stationID, new Tuple<string, string>( node.Attributes["stationName"].InnerText, node.Attributes["corporationName"].InnerText ) );
                            }
                            else // if station is already in list then update with outpost name and corp
                            {
                                sl[stationID] = new Tuple<string, string>( node.Attributes["stationName"].InnerText, node.Attributes["corporationName"].InnerText );
                            }
                        }
                        // Cache xml by writing a file to disk if eve api fetch was a success
                        if (!outpostsLoaded) WriteCachedOutposts( xmlDoc );
                    }
                }
            }
            // return the generated station list
            return sl;
        }

        // Store the outpost xml from Eve api
        private static void WriteCachedOutposts( XmlDocument document )
        {
            FileHandler filehandler = new FileHandler();
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            //writerSettings.OmitXmlDeclaration = true;
            writerSettings.Indent = true;
            writerSettings.Encoding = System.Text.Encoding.UTF8;
            try
            {
                using (XmlWriter xmlWriter = XmlWriter.Create( filehandler.AppDataPath + Path.DirectorySeparatorChar + Values.OUTPOST_XML_CACHE_NAME, writerSettings ))
                {
                    if (xmlWriter != null) document.Save( xmlWriter );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error writing Outpost data" );
            }


        }

        // retrieve the outpost xml stored locally
        private static bool ReadCachedOutposts( ref XmlDocument document )
        {
            FileHandler filehandler = new FileHandler();
            document = new XmlDocument();
            //XmlReaderSettings readerSettings = new XmlReaderSettings();
            //readerSettings.IgnoreWhitespace = true;
            try
            {
                using (XmlReader xmlReader = XmlReader.Create( filehandler.AppDataPath + Path.DirectorySeparatorChar + Values.OUTPOST_XML_CACHE_NAME ))
                {
                    document.Load( xmlReader );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error reading Outpost data" );
            }
            return document.HasChildNodes;
        }


        internal static Dictionary<int, string> GetRegionNames( DataTable dtNames )
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            foreach (DataRow dr in dtNames.Rows)
            {
                string sRegionName = dr["regionName"].ToString().Trim();
                d.Add( int.Parse( dr["regionID"].ToString() ), sRegionName );
            }
            return d;
        }


        internal static bool GetSolarSystemsInfo( DataTable dtInputSystemSecurity, ref Dictionary<int, string> slSystemNames, ref Dictionary<int, double> dSystemSecurity )
        {
            CultureInfo ci = CultureInfo.GetCultureInfo( "en-US" );
            //Dictionary<int, double> d = new Dictionary<int, double>();
            foreach (DataRow dr in dtInputSystemSecurity.Rows)
            {
                double dSec = Convert.ToDouble( dr["security"].ToString(), ci );
                //dSec = double.Parse( dr["security"].ToString(), NumberStyles.AllowDecimalPoint, Ci );
                int solarSystemID = int.Parse( dr["solarSystemID"].ToString() );

                // Ad system security to dictionary
                dSystemSecurity.Add( solarSystemID, dSec );

                // Also create sorted list of system names now that we are looping the list anyway
                slSystemNames.Add( solarSystemID, dr["solarSystemName"].ToString() );
            }
            return dSystemSecurity.Count > 0 && slSystemNames.Count > 0;
        }

        //internal static Dictionary<int, double> GetSystemSecurity( DataTable dtSystemSecurity )
        //{
        //    double dSec;
        //    CultureInfo ci = CultureInfo.GetCultureInfo( "en-US" );
        //    Dictionary<int, double> d = new Dictionary<int, double>();
        //    foreach (DataRow dr in dtSystemSecurity.Rows)
        //    {

        //        //dSec = double.Parse( dr["security"].ToString(), NumberStyles.AllowDecimalPoint, Ci );
        //        dSec = Convert.ToDouble( dr["security"].ToString(), ci );
        //        d.Add( int.Parse( dr["solarSystemID"].ToString() ), dSec );
        //    }
        //    return d;
        //}


        // Split by Sellers and buyers
        internal static void SplitLogEntries( ref DataTable dtLogEntries, ref DataView dvSellers, ref DataView dvBuyers )
        {
            dvSellers = new DataView( dtLogEntries, "bid = false", "price DESC", DataViewRowState.CurrentRows );

            dvBuyers = new DataView( dtLogEntries, "bid = true", "price ASC", DataViewRowState.CurrentRows );
        }


        //
        // MarketLog file handling
        //
        #region MarketLog file handling

        // field 
        private DataTable _dtCsv;

        public DataTable ProcessMarketLog( Stream strm, FileDataTypes iType, string sDataTableName, ref SortedList<long, Tuple<string, string>> slStationNames )
        {
            DataTable dtResult = null;
            switch ((FileDataTypes)iType)
            {
                case FileDataTypes.Csv:
                    dtResult = PopulateDataTableFromMarketLogDataFile( strm, sDataTableName, ref  slStationNames );
                    break;
            }
            return dtResult;
        }


        private DataTable PopulateDataTableFromMarketLogDataFile( Stream strm, string sDataTableName, ref SortedList<long, Tuple<string, string>> slStationNames )
        {
            StreamReader srdr = new StreamReader( strm );
            Int32 iLineCount = 0;
            do
            {
                String sLine = srdr.ReadLine();
                if (sLine == null)
                    break;
                if (0 == iLineCount++)
                    _dtCsv = CreateMarketLogEntriesTable();
                if (iLineCount > 1)
                    this.AddMarketLogEntryDataRowToTable( sLine, _dtCsv, ref slStationNames );
            } while (true);
            return _dtCsv;
        }

        private void AddMarketLogEntryDataRowToTable( String CSVLine, DataTable dt, ref SortedList<long, Tuple<string, string>> slStationNames )
        {
            String[] strVals = CSVLine.Split( new char[] { ',' } );
            DataRow dRow = dt.NewRow();
            CultureInfo ci = CultureInfo.GetCultureInfo( "en-US" ); // The culture of the marketlogs from Eve
            for (int i = 0 ; i < dt.Columns.Count ; i++)
            {
                Type tRowType = dt.Columns[i].DataType;
                switch (dt.Columns[i].ColumnName)
                {
                    case "solarSystemID":
                        // Filter on unwanted solar systems
                        dRow[i] = Convert.ChangeType( strVals[i].Trim(), tRowType, ci );
                        int iSolarSystemID = int.Parse( strVals[i].Trim() );
                        string sCurrentSystem = Values.slSolarSystems[iSolarSystemID];
                        if (Values.ExeptedSystems.Contains( sCurrentSystem )) return;
                        break;


                    case "volRemaining":
                        double dQuantity = Double.Parse( strVals[i].Trim(), ci );
                        if (dQuantity < Values.MinMarketQuantity) return; // don't apply row if quantity is less than specified
                        dRow[i] = dQuantity;//string.Format(Ci, "{0:0,0}", dQuantity);
                        break;
                    case "jumps":
                        switch (strVals[i].Trim())
                        {
                            case "0":
                                dRow[i] = "System";
                                break;
                            default:
                                dRow[i] = strVals[i].Trim();
                                break;
                        }
                        break;
                    case "price":
                        dRow[i] = Double.Parse( strVals[i].Trim(), ci );
                        break;
                    case "stationID":// if column is the stationID, then also find the station name
                        int iStationID = 0;
                        dRow[i] = iStationID = int.Parse( strVals[i].Trim() );
                        // set column[14] and column[17] to station and corp name based on id in column[10]

                        // Check if the station id exits in station name list
                        if (slStationNames.ContainsKey( iStationID ))
                        {
                            dRow[i + 4] = slStationNames[iStationID].Item1;
                            dRow[i + 7] = slStationNames[iStationID].Item2;
                        }
                        else // StationID not found so give error message if not offline
                        {
                            if (!Main.IsAppOffline)
                            {
                                Main.LightErrorMessage += string.Format( "The station with id {0} was not found in the database.\r\nYou should check \"Get outpost names from Eve API\" under File->Options.\r\n", iStationID );
                            }
                        }
                        break;
                    case "stationName":
                        // Handled by stationID case
                        break;
                    case "corporationName":
                        // Handled by stationID case
                        break;
                    case "range":
                        int iRange = int.MinValue;
                        try
                        {
                            iRange = int.Parse( strVals[i].Trim() );
                        }
                        catch (ArgumentNullException ex)
                        {
                            throw new Exception( "Column '" + dt.Columns[i].ColumnName + "' in row " + i.ToString() + " is null!", ex );
                        }
                        catch (ArgumentException ex)
                        {
                            throw new Exception( "Column '" + dt.Columns[i].ColumnName + "' in row " + i.ToString() + " has bad argument!", ex );
                        }
                        catch (OverflowException ex)
                        {
                            throw new Exception( "Overflow in trying to parse row " + i.ToString() + "in column '" + dt.Columns[i].ColumnName + "'!", ex );
                        }
                        catch (FormatException ex)
                        {
                            throw new Exception( "Column '" + dt.Columns[i].ColumnName + "' in row " + i.ToString() + " has bad format!", ex );
                        }
                        switch (iRange)
                        {
                            case -1:
                                dRow[i] = "Station";
                                break;
                            case 0:
                                dRow[i] = "System";
                                break;
                            case 32767:
                                dRow[i] = "Region";
                                break;
                            default:
                                dRow[i] = strVals[i].Trim() + " Jumps";
                                break;
                        }
                        break;
                    case "expires":
                        DateTime dateIssued = (DateTime)dRow["issued"];
                        int iDuration = (int)dRow["duration"];
                        // Calculate difference from now using eve time UTC
                        TimeSpan ts = dateIssued.AddDays( iDuration ).Subtract( DateTime.UtcNow );
                        dRow[i] = ts.Days.ToString() + "D " + ts.Hours.ToString() + "H " + ts.Minutes.ToString() + "M " + ts.Seconds.ToString() + "S";
                        // If time is negative, mark row with error
                        if (ts.Ticks < 0)
                        {
                            if (Values.IgnoreExpiredOrders) return; // Ignore orders expired, if set in options
                            dRow.SetColumnError( dt.Columns[i], Values.ORDER_DATE_EXPIRED );
                            dRow[i] = "---";
                        }
                        break;
                    case "Security":
                        try
                        {
                            //if (dRow["solarSystemID"] != System.DBNull.Value)
                            //{
                            double dSec = Values.dSystemSecurity[(int)dRow["solarSystemID"]];
                            // dRow[12] being the solarSystemID
                            // Filter log entries by system security status.
                            if (SecurityFilter( dSec )) return;
                            dRow[i] = dSec;
                            //}
                        }
                        catch (KeyNotFoundException)
                        {
                            MarketScanner.Main.LightErrorMessage += string.Format( "Error finding system with ID: {1} {0}", Environment.NewLine, dRow[12].ToString() );
                            return;
                        }
                        break;
                    default:
                        dRow[i] = Convert.ChangeType( strVals[i].Trim(), tRowType, ci );
                        break;
                }
            }
            dt.Rows.Add( dRow );
            return;
        }

        /// <summary>
        /// Filters security values based on input.
        /// <para>Private function.</para>
        /// </summary>
        /// <param name="dSec">The security status that we want to check</param>
        /// <returns>True if the input is less than the stored Values.MinSystemSecurity</returns>
        private bool SecurityFilter( double dSec )
        {
            // 0.0 will show all sec systems also below 0.0
            // if (Values.MinSystemSecurity == 0.0) return false; 
            // return false if the item is to be shown and true if it is to be filtered
            return dSec < Values.MinSystemSecurity;
        }

        #endregion

    }
}
