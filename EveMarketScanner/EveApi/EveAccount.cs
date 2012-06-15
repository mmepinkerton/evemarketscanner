using System;

namespace MarketScanner.EveApi
{
    [Serializable]
    public class EveAccount
    {

        #region Properties


        private int iAccountUserId;
        public int AccountUserId
        {
            get { return iAccountUserId; }
            set { iAccountUserId = value; }
        }

        /* Not used ATM
        private string sApiLimitedKey;
        public string ApiLimitedKey
        {
            get { return sApiLimitedKey; }
            set { sApiLimitedKey = value; }
        }
        */

        private string sApiFullKey;
        public string ApiFullKey
        {
            get { return sApiFullKey; }
            set { sApiFullKey = value; }
        }


        private EveCharater[] ecArrCharacterList = new EveCharater[3];

        public EveCharater[] CharacterList
        {
            get { return ecArrCharacterList; }
            set { ecArrCharacterList = value; }
        }

        private EveCharater ecSelectedChar;

        public EveCharater SelectedCharacter
        {
            get { return ecSelectedChar; }
            set { ecSelectedChar = value; }
        }


        #endregion


        #region Contructors

        public EveAccount() { }

        public EveAccount( int iAccUserId, string sApiKey )
        {
            AccountUserId = iAccUserId;
            ApiFullKey = sApiKey;
        }

        #endregion

        public static EveAccount GetStoredAccount()
        {
            //return Properties.Settings.Default.MinMarketQuantity;
            return new EveAccount();
        }
    }
}
