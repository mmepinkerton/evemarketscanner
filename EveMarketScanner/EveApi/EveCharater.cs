using System;
using System.Collections.Generic;
using System.Text;

namespace MarketScanner.EveApi
{
    public class EveCharater
    {
        private int iCharId;
        public int CharacterID
        {
            get { return iCharId; }
            set { iCharId = value; }
        }

        private string sCharName;
        public string CharacterName
        {
            get { return sCharName; }
            set { sCharName = value; }
        }

        private int iCorpId;
        public int CorporationID
        {
            get { return iCorpId; }
            set { iCorpId = value; }
        }

        private string sCorpName;

        public string CorporationName
        {
            get { return sCorpName; }
            set { sCorpName = value; }
        }

        public EveCharater() { }

        public EveCharater( int characterID, string characterName, int coporationID, string coporationName )
        {
            iCharId = characterID;
            sCharName = characterName;
            iCorpId = coporationID;
            sCorpName = coporationName;
        }

        public override string ToString()
        {
            return sCharName;
        }
    }
}
