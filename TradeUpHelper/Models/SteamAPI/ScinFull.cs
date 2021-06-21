using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models.SteamAPI
{
    class ScinFull : Scin
    {
        public string name { get; set; }
        public string market_hash_name { get; set; }
        public string market_name { get; set; }
        public ScinDescriptions[] descriptions { get; set; }
        public ScinDescriptions[] owner_descriptions { get; set; }
        public ScinActions[] actions { get; set; }
        public string icon_url { get; set; }


    }
}
