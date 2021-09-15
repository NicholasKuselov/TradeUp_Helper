using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;
using TradeUpHelper.Models;
using TradeUpHelper.Models.MarketChecker;
using TradeUpHelper.Models.SteamAPI;
using TradeUpHelper.ViewModels;

namespace TradeUpHelper.Controllers.MarketChecker
{
    class MarketChecker
    {
        public static RarityPainSeedScin SelectedScin { get { return parent.SelectedWeapon; } set { parent.SelectedWeapon = value; } }

        public static MarketCheckerPageVM parent;

        public static List<MarketCheckerScin> GetScinsFromSteamUrl(string data,string needScinCount, CancellationToken token)
        {
            double minPrice = -1;

            List<MarketCheckerScin> scins = new List<MarketCheckerScin>();

            int start = 0;

            int scinsCount = 100;

            int proxyIndex = 0;

            int addedScinCount = 0;
            int neededScinCount = 0;
            if (needScinCount.Equals(""))
            {
                neededScinCount = -1;
            }
            else
            {
                neededScinCount = Convert.ToInt32(needScinCount);
            }

            int totalScanedScinCount = 0;

            while (scinsCount > start)
            {
                string request = WebController.SendGet(data + "/render/?query=&start=" + start.ToString() + "&count=100&country=UA&language=russian&currency=" + App.Currency.SteamCode);


                ScinMarketPlacePage json = JsonSerializer.Deserialize<ScinMarketPlacePage>(request);

                if (!json.success)
                {
                    request = WebController.SendGet(data + "/render/?query=&start=" + start.ToString() + "&country=UA&language=russian&currency=" + App.Currency.SteamCode, ProxyHandler.ProxyList[proxyIndex]);
                    json = JsonSerializer.Deserialize<ScinMarketPlacePage>(request);
                    if (proxyIndex == ProxyHandler.ProxyList.Count-1)
                    {
                        proxyIndex = 0;
                    }
                    else
                    {
                        proxyIndex++;
                    }
                }

                scinsCount = json.total_count;

                int index = 0;
                foreach (ScinMarketPlacePage.ScinListingInfo item in json.listinginfo.Values)
                {
                    if (token.IsCancellationRequested)
                    {
                        parent.TotalScanedScinCount = totalScanedScinCount;
                        return scins;
                    }
                    string scinLink = item.asset.market_actions.First().link;
                    scinLink = scinLink.Replace("%listingid%", item.listingid).Replace("%assetid%", item.asset.id);
                    MarketCheckerScin tmpScin = JsonSerializer.Deserialize<MarketCheckerScin>(WebController.GetItemProp(scinLink));
                    tmpScin.price = (item.converted_price + item.converted_fee) / 100.0;

                    if (tmpScin.price == 0) continue;
                    
                    tmpScin.Index = index + start;
                    if (minPrice == -1)
                    {
                        minPrice = tmpScin.price;
                    }
                    tmpScin.MinPrice = minPrice;
                   
                    scins.Add(tmpScin);
                    totalScanedScinCount++;
                    addedScinCount++;
                    if (addedScinCount >= neededScinCount && neededScinCount > 0)
                    {
                        parent.TotalScanedScinCount = totalScanedScinCount;
                        return scins;
                    }
                    if (neededScinCount == -1)
                    {
                        parent.CheckProgress += ((95.0 / parent.CheckProgressCountStages) / (scinsCount - 1));
                    }
                    else
                    {
                        parent.CheckProgress += ((95.0 / parent.CheckProgressCountStages) / (neededScinCount - 1));
                    }
                    index++;
                }
                start += 100;
            }

            parent.TotalScanedScinCount = totalScanedScinCount;

            return scins;
        }

        public static List<MarketCheckerScin> GetScinsWithStickerScinsFromSteamURL(List<MarketCheckerScin> scins, CancellationToken token)
        {
            List<MarketCheckerScin> scinsWithStickers = new List<MarketCheckerScin>();

            for (int i = 0; i < scins.Count; i++)
            {
                if (scins[i].stickers != null)
                {
                    if (scins[i].stickers.Length > 0) {
                        for (int j = 0; j < scins[i].stickers.Length; j++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                return scinsWithStickers;
                            }
                            try
                            {
                                scins[i].stickers[j].price = PriceHandler.GetPriceFromSteamCache("Sticker | " + scins[i].stickers[j].name);
                            }
                            catch
                            {
                                scins[i].stickers[j].price = PriceHandler.GetPrice("Sticker | " + scins[i].stickers[j].name);
                            }

                            //if (scins[i].stickers[j].price <=0)
                            //{
                            //     //Wait for steam
                            //    j--;
                            //}
                        }
                        scinsWithStickers.Add(scins[i]);
                    }
                }
                parent.CheckProgress += ((95.0 / parent.CheckProgressCountStages) / scins.Count);
            }
            return scinsWithStickers;
        }

        public static List<MarketCheckerScin> GetScinsAlternative(string data, bool isStickersNeed, CancellationToken token)
        {

            List<MarketCheckerScin> scins = new List<MarketCheckerScin>();

            string[] dataSp = data.Split(new[] { "Buy Now" }, StringSplitOptions.None);
            //TODO: Переделать конструкцию определение языка стима
            if (dataSp.Length <= 1)
            {
                dataSp = data.Split(new[] { "Купить" }, StringSplitOptions.None);
            }

            foreach (string item in dataSp.Skip(1))
            {
                MarketCheckerScin tmpScin = new MarketCheckerScin();

                string[] vs = item.Split('\n');
                tmpScin.price = ConvertFloatToDouble(vs[1]);
                tmpScin.floatvalue = ConvertFloatToDouble(vs.FirstOrDefault(x => x.Contains("Float Value") || x.Contains("Float:")));
                tmpScin.paintseed = ConvertToInt(vs.FirstOrDefault(x => x.Contains("Paint Seed")));
                tmpScin.full_item_name = vs.FirstOrDefault(x => x.Contains("("));
                tmpScin.Name = tmpScin.full_item_name?.Split('(')?[0];
                //tmpScin.nametag = vs.First(x => x.Contains("Name Tag")) ?? "s";Купить

                if (item.Contains("Наклейка") || isStickersNeed)
                {
                    List<Sticker> stickers = new List<Sticker>();

                    string[] stick = item.Split(new[] { "Наклейка" }, StringSplitOptions.None);

                    foreach (string st in stick.Skip(1))
                    {
                        if (token.IsCancellationRequested)
                        {
                            return scins;
                        }
                        Sticker sticker = new Sticker();
                        string[] cs1 = st.Split('\n');
                        sticker.name = ("Наклейка" + cs1[0]).Replace('\r', ' ');
                        //TODO : Добавить поле износа в класс наклейки
                        //sticker.wear = cs1[3];
                        sticker.StickerNameLang = StickerNameLang.RU;
                        stickers.Add(sticker);
                    }

                    tmpScin.stickers = stickers.ToArray();
                }
                else if (item.Contains("Sticker") || isStickersNeed)
                {
                    List<Sticker> stickers = new List<Sticker>();

                    string[] stick = item.Split(new[] { "Sticker" }, StringSplitOptions.None);

                    foreach (string st in stick.Skip(1))
                    {
                        if (token.IsCancellationRequested)
                        {
                            return scins;
                        }
                        Sticker sticker = new Sticker();
                        string[] cs1 = st.Split('\n');
                        sticker.name = ("Sticker" + cs1[0]).Replace('\r', ' ');
                        //TODO : Добавить поле износа в класс наклейки
                        //sticker.wear = cs1[3];
                        sticker.StickerNameLang = StickerNameLang.EN;
                        stickers.Add(sticker);
                    }

                    tmpScin.stickers = stickers.ToArray();
                }
                parent.CheckProgress += ((95.0 / parent.CheckProgressCountStages) / (dataSp.Length - 1));
                scins.Add(tmpScin);
            }

            for (int i = 0; i < scins.Count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return scins;
                }
                scins[i].MinPrice = scins[0].price;
            }


            return scins;
        }

        public static List<MarketCheckerScin> GetScins(string data, bool isStickersNeed, CancellationToken token)
        {
            //data = File.ReadAllText("C:\\Users\\Odin\\Desktop\\sss.txt");
            List<MarketCheckerScin> scins = new List<MarketCheckerScin>();

            string[] dataSp = data.Split(new[] { "Buy Now" }, StringSplitOptions.None);

            if (dataSp.Length <= 1) dataSp = data.Split(new[] { "Купить" }, StringSplitOptions.None);

            foreach (string item in dataSp.Skip(1))
            {
                MarketCheckerScin tmpScin = new MarketCheckerScin();
                string[] vs = item.Split('\n');
                if (item.Contains("Name Tag"))
                {
                    tmpScin.price = ConvertFloatToDouble(vs[1]); //1
                    tmpScin.floatvalue = ConvertFloatToDouble(vs[5]); // 4
                    tmpScin.paintseed = ConvertToInt(vs[6]); //5
                    tmpScin.full_item_name = vs[3]; //3
                    tmpScin.Name = vs[3].Split('(')[0];
                }
                else
                {
                    tmpScin.price = ConvertFloatToDouble(vs[1]); //1
                    tmpScin.floatvalue = ConvertFloatToDouble(vs[4]); // 4
                    tmpScin.paintseed = ConvertToInt(vs[5]); //5
                    tmpScin.full_item_name = vs[3]; //3
                    tmpScin.Name = vs[3].Split('(')[0];
                }

                if (item.Contains("Sticker") || isStickersNeed)
                {
                    List<Sticker> stickers = new List<Sticker>();

                    string[] stick = item.Split(new[] { "Sticker" }, StringSplitOptions.None);

                    foreach (string st in stick.Skip(1))
                    {
                        if (token.IsCancellationRequested)
                        {
                            return scins;
                        }
                        Sticker sticker = new Sticker();
                        string[] cs1 = st.Split('\n');
                        sticker.name = ("Sticker" + cs1[0]).Replace('\r', ' ');
                        //TODO : Добавить поле износа в класс наклейки
                        //sticker.wear = cs1[3];
                        stickers.Add(sticker);
                    }

                    tmpScin.stickers = stickers.ToArray();
                }
                parent.CheckProgress += ((95.0 / parent.CheckProgressCountStages) / (dataSp.Length - 1));

                scins.Add(tmpScin);
            }

            for (int i = 0; i < scins.Count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return scins;
                }
                scins[i].MinPrice = scins[0].price;
            }


            return scins;
        }

        public static List<MarketCheckerScin> GetStickerPrice(List<MarketCheckerScin> scins, CancellationToken token)
        {
            for (int i = 0; i < scins.Count; i++)
            {
                if (scins[i].stickers != null)
                {
                    for (int j = 0; j < scins[i].stickers.Length; j++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return scins;
                        }
                        if (scins[i].stickers[j].StickerNameLang == StickerNameLang.EN)
                        {
                            scins[i].stickers[j].price = PriceHandler.GetPrice(scins[i].stickers[j].name.Substring(0, scins[i].stickers[j].name.Length - 1));
                        }
                        else if (scins[i].stickers[j].StickerNameLang == StickerNameLang.RU)
                        {
                            try
                            {
                                string engName = TradeUpHelperAPI.GetStickerByRus(scins[i].stickers[j].name.Substring(scins[i].stickers[j].name.IndexOf('|')+2, scins[i].stickers[j].name.Length - 3 - scins[i].stickers[j].name.IndexOf('|'))).stickers[0].name_eng;
                                scins[i].stickers[j].price = PriceHandler.GetPrice("Sticker | "+engName);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                scins[i].stickers[j].price = -1;
                            }                           
                        }
                    }
                }
                parent.CheckProgress += ((95.0 / parent.CheckProgressCountStages) / scins.Count);
            }

            return scins;
        }

        public static List<MarketCheckerScin> CheckPaintSeed(List<MarketCheckerScin> scins, RarityPainSeedScin name, CancellationToken token)
        {
            List<MarketCheckerScin> checkerScins = new List<MarketCheckerScin>();
            List<RariryPainSeed> seeds = name.Seeds;


            for (int i = 0; i < scins.Count; i++)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (token.IsCancellationRequested)
                    {
                        return checkerScins;
                    }
                    if (seeds[j].Seeds.Contains(scins[i].paintseed))
                    {
                        scins[i].RariryPainSeed = seeds[j];
                        checkerScins.Add(scins[i]);
                    }
                }
                //MessageBox.Show(((95.0 / parent.CheckProgressCountStages) / scins.Count).ToString() + " seed");
                parent.CheckProgress += ((95.0 / parent.CheckProgressCountStages) / scins.Count);
            }


            return checkerScins;
        }

        public static List<MarketCheckerScin> GetScinsWithSticker(List<MarketCheckerScin> scins, CancellationToken token)
        {
            List<MarketCheckerScin> checkerScins = new List<MarketCheckerScin>();



            for (int i = 0; i < scins.Count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return checkerScins;
                }
                if (scins[i].stickers != null)
                {
                    if (scins[i].stickers.Length > 0)
                    {
                        checkerScins.Add(scins[i]);
                    }
                }

            }


            return checkerScins;
        }

        public static double GetAllStickerPrice(Scin scin, CancellationToken token)
        {
            if (scin.stickers == null) return 0.0;
            double price = 0.0;
            for (int i = 0; i < scin.stickers.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return price;
                }
                price += scin.stickers[i].price;
            }
            return price;
        }

        private static double ConvertFloatToDouble(string Float)
        {
            if (Float == null) return 0.0;
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

        private static int ConvertToInt(string Float)
        {
            if (Float == null) return 0;
            string newFloat = "";
            for (int i = 0; i < Float.Length; i++)
            {
                if (Char.IsDigit(Float[i]))
                {
                    newFloat = newFloat + Float[i];
                }
            }
            if (newFloat.Length == 0) return 0;
            return Convert.ToInt32(newFloat);
        }
    }
}
