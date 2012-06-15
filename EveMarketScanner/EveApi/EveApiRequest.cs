using System;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;

namespace MarketScanner.EveApi
{
    /// <summary>
    /// A simple API request class
    /// </summary>
    public class EveApiRequest
    {
        public EveApiRequest() { }


        /// <summary>
        /// Fetches a generic xml result from the eve API, checking for error messages.
        /// </summary>
        /// <param name="url">The url to be fetched</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument FetchXmlData( string url )
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load( url );
            }
            catch (Exception)
            {
                throw new Exception( "Could Not connect to Eve API. Check your Connection or the server might be down!" );
            }
            XmlNodeList nodes = xmlDoc.SelectNodes( "//error" );
            if (nodes != null && nodes.Count > 0)
            {
                throw new Exception( nodes[0].InnerText );
            }
            return xmlDoc;
        }

    }






    /// <summary>
    /// 
    /// </summary>
    public class EveAuthenticatedApiRequest
    {

        #region properties

        private EveAccount eaCurAccount;

        public EveAccount CurrentAccount
        {
            get { return eaCurAccount; }
            set { eaCurAccount = value; }
        }

        #endregion

        public EveAuthenticatedApiRequest()
        {

        }

        public EveAuthenticatedApiRequest( EveAccount curAccount )
        {
            CurrentAccount = curAccount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal XmlDocument GetXML( string path )
        {
            if (CurrentAccount != null)
            {
                try
                {
                    // Create a request using a URL that can receive a post. 
                    WebRequest request = WebRequest.Create( path );
                    request.Method = "POST";
                    string postData = "userid=" + CurrentAccount.AccountUserId + "&apikey=" + CurrentAccount.ApiFullKey;
                    byte[] byteArray = Encoding.UTF8.GetBytes( postData );
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write( byteArray, 0, byteArray.Length );
                    dataStream.Close();

                    // Get the response.
                    WebResponse response = request.GetResponse();
                    // Read the content.
                    StreamReader reader = new StreamReader( dataStream );
                    string responseFromServer = reader.ReadToEnd();
                }
                catch (Exception)
                {

                    throw;
                }

            }


            return new XmlDocument();
        }

    }
}
