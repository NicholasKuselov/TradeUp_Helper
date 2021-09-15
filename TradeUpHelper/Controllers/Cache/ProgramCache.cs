using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Constants;

namespace TradeUpHelper.Controllers.Cache
{
    class ProgramCache
    {
        public static Cache LootFarmPrice { get; } = new Cache() { CachePath = FilePath.LOOTFARM_PRICE_CACHE };
        public static Cache SteamPrice { get; } = new Cache() { CachePath = FilePath.STEAM_PRICE_CACHE };

        public class Cache
        {
            public string CachePath { get; set; }

            public void Write(string data)
            {
                File.WriteAllText(CachePath, data);
            }

            public string Read()
            {
                return File.ReadAllText(CachePath);
            }
        }
    }
}
