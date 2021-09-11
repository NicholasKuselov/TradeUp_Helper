using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradeUpHelper.Constants;
using TradeUpHelper.Models;

namespace TradeUpHelper.Controllers
{
    class PriceHandler
    {
        private static PriceDBLootFarm[] priceDBLootFarms;

        public static void Load()
        {
            priceDBLootFarms = JsonSerializer.Deserialize<PriceDBLootFarm[]>(WebController.SendGet(WebPath.LootFarmPriceDBFile));
        }
        
        public static double GetPrice (string itemName)
        {
            try
            {
                return InventoryHandler.GetPriceFromSteam(itemName);
            }
            catch
            {
                return priceDBLootFarms.First(p => p.name.Equals(itemName)).GetPrice;
            }
        }
            
    }
}
