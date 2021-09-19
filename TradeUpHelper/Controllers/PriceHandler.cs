using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers.Cache;
using TradeUpHelper.Models;

namespace TradeUpHelper.Controllers
{
    class PriceHandler
    {
        private static PriceDBLootFarm[] priceDBLootFarms;

        public static List<SteamPriceCache> SteamPriceCaches;
        private const int STEAM_PRICE_CACHE_LIFE_TIME = 5;
        public static void Load()
        {
            try
            {
                string data = WebController.SendGet(WebPath.LootFarmPriceDBFile);
                priceDBLootFarms = JsonSerializer.Deserialize<PriceDBLootFarm[]>(data);
                ProgramCache.LootFarmPrice.Write(data);
            }catch
            {
                try
                {
                    string data = ProgramCache.LootFarmPrice.Read();
                    priceDBLootFarms = JsonSerializer.Deserialize<PriceDBLootFarm[]>(data);
                }
                catch
                {
                    priceDBLootFarms = new PriceDBLootFarm[] { };
                }
            }

            try
            {
                string data = ProgramCache.SteamPrice.Read();
                SteamPriceCaches = JsonSerializer.Deserialize<List<SteamPriceCache>>(data);
                
                for (int i = 0; i < SteamPriceCaches.Count; i++)
                {
                    try
                    {
                        string[] dateSp = SteamPriceCaches[i].Date.Split('.');
                        if (DateTime.Today > new DateTime(Convert.ToInt32(dateSp[2]), Convert.ToInt32(dateSp[1]), Convert.ToInt32(dateSp[0])).AddDays(STEAM_PRICE_CACHE_LIFE_TIME))
                        {
                            SteamPriceCaches.RemoveAt(i);
                            i--;
                        }
                    }
                    catch {
                        SteamPriceCaches.RemoveAt(i);
                        i--;
                    }
                }
                ProgramCache.SteamPrice.Write(JsonSerializer.Serialize(SteamPriceCaches));
            }
            catch
            {
                SteamPriceCaches = new List<SteamPriceCache>();
            }
        }
        
        public static double GetPrice (string itemName)
        {
            try
            {
                double priceUSD = priceDBLootFarms.First(p => p.name.Equals(itemName)).GetPrice;
                return priceUSD * App.Currency.ExchangeRatesToUSD;
            }
            catch
            {
                return InventoryHandler.GetPriceFromSteam(itemName);
            }
        }

        public static double GetPriceFromSteamCache(string itemName)
        {
            return Convert.ToDouble(SteamPriceCaches.First(item => item.Name.Equals(itemName)).Price);
        }
        
        public static void AddItemToSteamCache(string itemName,double price)
        {
            SteamPriceCaches.Add(new SteamPriceCache() { Name = itemName, Price = price.ToString(), Date = DateTime.Now.ToShortDateString() });
            Cache.ProgramCache.SteamPrice.Write(JsonSerializer.Serialize(SteamPriceCaches));
        }
        public class SteamPriceCache
        {
            public string Name { get;set;}
            public string Price { get; set; }
            public string Date { get; set; }

        }
    }
}
