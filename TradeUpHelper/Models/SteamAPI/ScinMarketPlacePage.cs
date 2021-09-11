using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models.SteamAPI
{
    class ScinMarketPlacePage
    {
        public bool success { get; set; }
        public int start { get; set; }
        public string pagesize { get; set; }
        public int total_count { get; set; }
        public Dictionary<long, ScinListingInfo> listinginfo { get; set; }

        public class ScinListingInfo
        {
            public string listingid { get; set; }
            public int price { get; set; }
            public int converted_price { get; set; }
            public int converted_fee { get; set; }

            public int fee { get; set; }
            public Asset asset { get; set; }
            
            public class Asset
            {
                public string id { get; set; }
                public List<ScinActions> market_actions { get; set; }
            }

        }
    }
}
