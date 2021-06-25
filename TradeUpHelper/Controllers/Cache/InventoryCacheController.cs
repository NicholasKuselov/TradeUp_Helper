using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;
using TradeUpHelper.Models.Cache;

namespace TradeUpHelper.Controllers.Cache
{
    class InventoryCacheController
    {
        
        public static void Load()
        {
            try
            {
                string inventoryJson = File.ReadAllText(FilePath.inventoryCacheFile);
                InventoryCache inventoryCache = JsonSerializer.Deserialize<InventoryCache>(inventoryJson);
                InventoryHandler.items = inventoryCache.Scins;
                InventoryHandler.CacheWritingTime = inventoryCache.LoadDate;
            }
            catch
            {
                MessageBox.Show((string)Application.Current.Resources["ErrorWithLoadingInventoryCache"]);
                InventoryHandler.LoadItems();
            }
        }

        public static void Save()
        {
            InventoryCache inventoryCache = new InventoryCache();
            InventoryHandler.CacheWritingTime = inventoryCache.LoadDate;
            File.WriteAllText(FilePath.inventoryCacheFile, JsonSerializer.Serialize(inventoryCache));
        }
    }
}
