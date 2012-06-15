using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using MarketScanner.EveApi;


namespace MarketScanner
{
    #region Enums

    internal enum FileDataTypes
    {
        Csv,
        Text,
        Other
    }

    internal enum FormatDgvType
    {
        Sellers,
        Buyers
    }

    internal enum BestBargainTypes
    {
        LowestSell = 1,
        SecondLowestSell,
        HighestBuy,
        SecondHighestBuy,
        HighestBidderLowestRegion,
        SecondHighestBidderLowestRegion,
        LowestSellerHighestRegion,
        SecondLowestSellerHighestRegion,
        LowestBuy,
        HighestSell
    }

    #endregion

    internal static class Values
    {
        public const string APP_TITLE = "Eve Market Scanner";
        public const string RELATIVE_MARKETLOGS_DIR = @"\EVE\logs\Marketlogs";
        public const string APP_RESOURCE_STATIONS_XML = @"\resources\Stations.xml.gz";
        public const string APP_RESOURCE_REGIONS_XML = @"\resources\Regions.xml.gz";
        public const string APP_RESOURCE_SOLARSYSTEMS_XML = @"\resources\SolarSystems.xml.gz";
        public const string APP_RESOURCE_ITEMS_XML = @"\resources\MarketItems.xml.gz";
        public const string ORDER_DATE_EXPIRED = "Market order expired!";
        public const string MSG_ERROR = "An error has occcured";
        public const string MSG_SELECT_REGION = "Select a region...";
        public const string MSG_SELECT_ITEM = "Select an item...";
        public const string MSG_NO_LOGS = "No MarketLogs Found!";
        public const string OUTPOST_XML_CACHE_NAME = @"cached_outposts.xml";
        public const string DISCLAIMER = @"
Disclaimer:
This software is provided by the copyright holders and contributors ""AS IS"" and any express or implied warranties, including, but not limited to, the implied warranties of merchantability and fitness for a particular purpose are disclaimed. In no event shall the copyright owner or contributors be liable for any direct, indirect, incidental, special, exemplary, or consequential damages (including, but not limited to, procurement of substitute goods or services; loss of use, data, or profits; or business interruption) however caused and on any theory of liability, whether in contract, strict liability, or tort (including negligence or otherwise) arising in any way out of the use of this software, even if advised of the possibility of such damage.";
        public const string DISCLAIMER_SHORT = @"

Disclaimer:
        This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.";

        public const string BARGAIN_FINDER_INFO = @"
Buy: The region with lowest selling price.

Sell: The region with highest bid price.

Place buy order: The region with lowest bid of all regions highest bidders.
                           I.e. lowest high buy bid.

Place sell order: The region with highest sell price of all regions lowest sell prices.
                            I.e. highest low sell price.";


        public static string sAppPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string sMyDocumentsPath = Environment.GetFolderPath( Environment.SpecialFolder.Personal ).ToString();
        public static string sDefaultMarketLogPath = string.Concat( sMyDocumentsPath, Values.RELATIVE_MARKETLOGS_DIR );

        // Application icon pulled from executable (Think it's a downsampled 16x16 version from the original 32x32 embedded)
        public static Icon icoAppIcon = Icon.ExtractAssociatedIcon( System.Reflection.Assembly.GetExecutingAssembly().Location );

        // Eve API
        public const string APIBASE = "http://api.eve-online.com";
        public static string sApiCharListUrl = "/account/Characters.xml.aspx";
        public static string sApiWalletTransactionsUrl = "/char/WalletTransactions.xml.aspx";
        public static string sApiWalletJournalUrl = "/char/WalletJournal.xml.aspx";
        public static string sApiConquerableStationListUrl = "/eve/ConquerableStationList.xml.aspx";
        //public static string m_ApiTrainingSkill = "/char/SkillIntraining.xml.aspx";
        //public static string m_ApiCharacterSheet = "/char/CharacterSheet.xml.aspx";


        // DataTable for logs and helper data
        public static DataTable dtMarketLogsListTable = DataHandler.CreateMarketLogsListTable();
        // Station names
        public static DataTable dtStationNames = DataHandler.DataTableFromCompressedXmlFile( Values.sAppPath + Values.APP_RESOURCE_STATIONS_XML );
        public static SortedList<long, Tuple<string, string>> slStationNames = DataHandler.GetStationNames( dtStationNames, ReadConquerableStationsFromApi );
        // Region names
        public static DataTable dtRegionNames = DataHandler.DataTableFromCompressedXmlFile( Values.sAppPath + Values.APP_RESOURCE_REGIONS_XML );
        public static Dictionary<int, string> dRegionNames = DataHandler.GetRegionNames( dtRegionNames );
        // System security rating and system names
        public static DataTable dtSystemSecurity = DataHandler.DataTableFromCompressedXmlFile( Values.sAppPath + Values.APP_RESOURCE_SOLARSYSTEMS_XML );
        public static Dictionary<int, string> slSolarSystems = new Dictionary<int, string>();
        public static Dictionary<int, double> dSystemSecurity = new Dictionary<int, double>();
        private static bool b = DataHandler.GetSolarSystemsInfo( dtSystemSecurity, ref slSolarSystems, ref dSystemSecurity ); // b is just an unused variable, but needed to invoke a function in a static context, it seems...



        #region Properties.Settings

        private static string sUserMarketLogPath;
        public static string UserMarketLogPath
        {
            get { return sUserMarketLogPath; }
            set { sUserMarketLogPath = value; }
        }

        internal static string MarketLogPath
        {
            get { return string.IsNullOrEmpty( Properties.Settings.Default.MyMarketLogPath ) || Properties.Settings.Default.MyMarketLogPath == string.Empty ? Properties.Settings.Default.MyMarketLogPath = sDefaultMarketLogPath : Properties.Settings.Default.MyMarketLogPath; }
            set
            {
                Properties.Settings.Default.MyMarketLogPath = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static bool LoadLogsOnStartup
        {
            get { return Properties.Settings.Default.MyLoadLogsOnStartup; }
            set
            {
                Properties.Settings.Default.MyLoadLogsOnStartup = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static bool IsLogsDateFilterSet
        {
            get { return Properties.Settings.Default.MyLogsDateFilterEnabled; }
            set
            {
                Properties.Settings.Default.MyLogsDateFilterEnabled = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static DateTime LogsDateFilter
        {
            get { return Properties.Settings.Default.MyLogsDateFilter; }
            set
            {
                Properties.Settings.Default.MyLogsDateFilter = value;
                Properties.Settings.Default.Save();
            }
        }


        internal static bool ReadConquerableStationsFromApi
        {
            get { return Properties.Settings.Default.ReadConquerableStationsFromApi; }
            set
            {
                Properties.Settings.Default.ReadConquerableStationsFromApi = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static long MinMarketQuantity
        {
            get { return Properties.Settings.Default.MinMarketQuantity; }
            set
            {
                Properties.Settings.Default.MinMarketQuantity = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static double MinSystemSecurity
        {
            get { return Properties.Settings.Default.MinSystemSecurity; }
            set
            {
                Properties.Settings.Default.MinSystemSecurity = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static EveAccount SavedEveAccount
        {
            get { return Properties.Settings.Default.SavedEveAccount; }
            set
            {
                Properties.Settings.Default.SavedEveAccount = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static bool IsMarketBrowserClosed
        {
            get { return Properties.Settings.Default.IsMarketBrowserClosed; }
            set
            {
                Properties.Settings.Default.IsMarketBrowserClosed = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static bool ShowAllAvailableMarketItemsInTreeView
        {
            get { return Properties.Settings.Default.ShowAllAvailableMarketItemsInTreeView; }
            set
            {
                Properties.Settings.Default.ShowAllAvailableMarketItemsInTreeView = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static ArrayList ExeptedSystems
        {
            get
            {
                if (Properties.Settings.Default.ExeptedSystems == null)
                {
                    Properties.Settings.Default.ExeptedSystems = new ArrayList();
                }
                return Properties.Settings.Default.ExeptedSystems;
            }
            set
            {
                Properties.Settings.Default.ExeptedSystems = value;
                Properties.Settings.Default.Save();
            }
        }

        internal static bool IgnoreExpiredOrders
        {
            get { return Properties.Settings.Default.IgnoreExpiredOrders; }
            set
            {
                Properties.Settings.Default.IgnoreExpiredOrders = value;
                Properties.Settings.Default.Save();
            }
        }


        internal static ContextMenuStrip SellersL
        {
            get
            {
                if (Properties.Settings.Default.SellersL == null)
                {
                    Properties.Settings.Default.SellersL = new ContextMenuStrip();
                }
                return Properties.Settings.Default.SellersL;
            }
            set
            {
                Properties.Settings.Default.SellersL = value;
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        /// <summary>
        ///        <para>
        ///            Returns a value indicating whether the specified path is properly formatted.
        ///        </para>
        /// </summary>
        /// <param name="path">
        ///        A <see cref="String"/> containing the path to check.
        /// </param>
        /// <returns>
        ///        <see langword="true"/> if <paramref name="path"/> is properly formatted; otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool IsPathValid( string path )
        {
            if (path == null || path.Trim().Length == 0)
                return false;
            try
            {
                DirectoryInfo di = new DirectoryInfo( path );
                return di.Exists;
            }
            catch (ArgumentException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (NotSupportedException)
            {
            }
            catch (PathTooLongException)
            {
            }
            return false;
        }
    }
}
