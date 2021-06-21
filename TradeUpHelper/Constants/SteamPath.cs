using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Constants
{
    class SteamPath
    {
        public static string BaseImageUrl { get; } = "https://community.akamai.steamstatic.com/economy/image/"; //в конце можно указать размер, например /330x192
        public static string SteamMarketSearch { get; } = "https://www.steamcommunity.com/market/search?q=";
    }
}
