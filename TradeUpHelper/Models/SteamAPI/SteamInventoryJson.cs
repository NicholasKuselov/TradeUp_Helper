using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models.SteamAPI
{
    class SteamInventoryJson
    {
        public bool success { get; set; }
        public string Error { get; set; }
        public Dictionary<long, ScinShort> rgInventory { get; set; }
        public Dictionary<String, ScinFull> rgDescriptions {get; set; }
    }
}
