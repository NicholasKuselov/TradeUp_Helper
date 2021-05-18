using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TradeUpHelper.Constants;
using TradeUpHelper.Models;

namespace TradeUpHelper.Controllers
{
    class CraftHistoryHandler
    {
        public static List<Craft> crafts;

        public static void Load()
        {

            try
            {
                string jsonString = File.ReadAllText(FilePath.CraftHistoryPath);

                crafts = JsonSerializer.Deserialize<List<Craft>>(jsonString);
            }catch
            {
                crafts = new List<Craft>();
            }
        }

        public static void Save()
        {
            try
            {

                string jsonString = JsonSerializer.Serialize(crafts);
                File.WriteAllText(FilePath.CraftHistoryPath, jsonString);
            }
            catch
            {
                
            }
        }

        public static void AddCraft(Craft craft)
        {
            crafts.Insert(0,craft);
        }

        public static int GetCraftCount()
        {
            return crafts.Count;
        }


    }
}
