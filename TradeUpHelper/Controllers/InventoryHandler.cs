using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.XPath;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers.Cache;
using TradeUpHelper.Models;
using TradeUpHelper.Models.SteamAPI;

namespace TradeUpHelper.Controllers
{
    class InventoryHandler
    {
        public static List<Scin> items = new List<Scin>();
        public static string CacheWritingTime = "";
        private static Random random = new Random();
        public static bool LoadItems()
        {
            try
            {
                if (SettingController.UserInventoryURL.Length < 5) return false;
                items.Clear();
                string inventoryJson = WebController.GetInventory();
                SteamInventoryJson data = JsonSerializer.Deserialize<SteamInventoryJson>(inventoryJson);
                if (!data.success)
                {
                    ErrorHandler.ShowError(Errors.ERROR, data.Error);
                    return false;
                }
                for (int i = 0; i < data.rgInventory.Count; i++)
                {
                    if (data.rgDescriptions[data.rgDescriptions.Keys.ElementAt(i)].actions != null)
                    {
                        string url = data.rgDescriptions[data.rgDescriptions.Keys.ElementAt(i)].actions[0].link;
                        string[] dataSp = url.Split('%');
                        url = dataSp[0] + "%" + dataSp[1] + SettingController.UserProfileId + dataSp[3] + data.rgInventory[data.rgInventory.Keys.ElementAt(i)].id + dataSp[5];
                        string itemJson = WebController.GetItemProp(url);
                        Scin tmp = JsonSerializer.Deserialize<Scin>(itemJson);
                        tmp.imageurl = SteamPath.BaseImageUrl + data.rgDescriptions[data.rgDescriptions.Keys.ElementAt(i)].icon_url;
                        tmp.price = PriceHandler.GetPrice(tmp.full_item_name);

                        items.Add(tmp);
                    }
                    else
                    {
                        Scin tmp = new Scin();
                        tmp.full_item_name = data.rgDescriptions[data.rgDescriptions.Keys.ElementAt(i)].market_hash_name;
                        tmp.Name = data.rgDescriptions[data.rgDescriptions.Keys.ElementAt(i)].market_hash_name;
                        tmp.imageurl = SteamPath.BaseImageUrl + data.rgDescriptions[data.rgDescriptions.Keys.ElementAt(i)].icon_url;
                        tmp.price = PriceHandler.GetPrice(tmp.full_item_name);
                        items.Add(tmp);
                    }
                    Task.Run(() =>
                    {
                        InventoryCacheController.Save();
                    });
                    return true;
                }
            }catch(Exception e)
            {
                ErrorHandler.WriteErrorLog(e,typeof(InventoryHandler).Name);
                return false;
            }

            return false;       
        }

        public static double GetPrice2(string itemName)
        {
            string rez = "";
            try
            {
                string url = SteamPath.SteamMarketSearch + itemName.Replace(' ', '+');
                rez = WebController.SendGet(url);
                //File.WriteAllText("ssssssssssssssssssss.txt",rez);

                int a = rez.IndexOf("normal_price");
                int b = rez.IndexOf("normal_price", a + 2);
                int c = rez.IndexOf(">", b + 2);
                int d = rez.IndexOf("<", c);
               // MessageBox.Show(ConvertFloatToDouble(rez.Substring(c + 2, d - c - 6)).ToString());
                return ConvertFloatToDouble(rez.Substring(c + 2, d - c - 6));
            }catch
            {
                return -3.0;
            }
        }
        

        public static double GetPriceFromSteam(string itemName)
        {
            string rez = "";
            try
            {
                string url = SteamPath.SteamPriceRequestStart + itemName + SteamPath.SteamPriceRequestEnd;
                rez = WebController.SendGet(url);
                ScinPrice scinPrice = JsonSerializer.Deserialize<ScinPrice>(rez);
                Thread.Sleep(1000);
                double price = ConvertFloatToDouble(scinPrice.lowest_price);
                if (price > 0)
                {
                    PriceHandler.AddItemToSteamCache(itemName, price);
                }
                return price;
            }
            catch (Exception e)
            {
                ErrorHandler.WriteErrorLog(e);
                return -1.0;
            }
        }

        static double ConvertFloatToDouble(string Float)
        {
            try
            {
                Float = Float.Replace('.', ',');
                string newFloat = "";
                for (int i = 0; i < Float.Length; i++)
                {
                    if (Char.IsDigit(Float[i]) || Float[i].Equals(','))
                    {
                        newFloat = newFloat + Float[i];
                    }
                }
                if (newFloat.Length == 0) return 0.0;
                return Convert.ToDouble(newFloat);
            }
            catch
            {
                return -1.0;
            }
        }
    }
}
