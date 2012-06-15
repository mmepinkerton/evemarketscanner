using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using MarketScanner.EveApi;

namespace MarketScanner
{
    public partial class Wallet : Form
    {

        private EveAccount _ea;

        public EveAccount CurEveAccount
        {
            get
            {
                if (_ea == null)
                    _ea = new EveAccount();
                return _ea;
            }
            set { _ea = value; }
        }


        public Wallet()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create( "http://api.eve-online.com/account/Characters.xml.aspx" );
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "userid=1019336&apikey=MgpSLvvxgQemZfy4dUGwtnQFnOhjOExnjoZmFDx4SvIqe9TWMxPTRIpd5TFjoc4p";
            byte[] byteArray = Encoding.UTF8.GetBytes( postData );
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write( byteArray, 0, byteArray.Length );
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();


            // Display the status.
            label1.Text = ((HttpWebResponse)response).StatusDescription;
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();


            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader( dataStream );
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            textBox1.Text = responseFromServer;


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml( responseFromServer );


            EveCharater[] charList = new EveCharater[3];

            if (xmlDoc != null)
            {
                XmlNodeList xmlCharacterNodes = xmlDoc.SelectNodes( "//rowset/row" );
                if (xmlCharacterNodes.Count > 0)
                {
                    int i = 0;
                    foreach (XmlNode character in xmlCharacterNodes)
                    {
                        XmlAttributeCollection xac = character.Attributes;
                        string sCharName = xac["name"].InnerText;
                        int iCharId = Int32.Parse( xac["characterID"].InnerText );
                        string sCorpName = xac["corporationName"].InnerText;
                        int iCorpId = Int32.Parse( xac["corporationID"].InnerText );
                        charList[i++] = new EveCharater( iCharId, sCharName, iCorpId, sCorpName );
                    }
                }

            }

            CurEveAccount.CharacterList = charList;


            SelectCharacter sc = new SelectCharacter(  CurEveAccount );
            sc.CharacterSelected += new CharacterSelectedEventHandler( sc_CharacterSelected );
            sc.Show(this);

            CurEveAccount.AccountUserId = 996611;


            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        void sc_CharacterSelected( object sender, EventArgs e )
        {
            //EveAccount ea = (EveAccount)sender;
            label1.Text = CurEveAccount.SelectedCharacter.CharacterName;
            Values.SavedEveAccount = CurEveAccount;
        }

        private void button2_Click( object sender, EventArgs e )
        {
            ConnectToApi cta = new ConnectToApi();
            cta.Show(this);
        }

    }

}