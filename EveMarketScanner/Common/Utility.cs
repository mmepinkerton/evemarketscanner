using System.Collections.Generic;

namespace MarketScanner.Common
{
    static class Utility
    {

        static public int findSecondRegion( List<KeyValuePair<int, double>> dicPrices )
        {
            for (int i = 1 ; i < dicPrices.Count ; i++)
            {
                if (dicPrices[i].Key != dicPrices[i - 1].Key)
                {
                    return dicPrices[i].Key;
                }
            }
            return 0; // select none if no region exists
        }
    }
}
