using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Models;
using TradeUpHelper.Models.MarketChecker;

namespace TradeUpHelper.Controllers.MarketChecker
{
    class MarketChecker
    {
        public static List<MarketCheckerScin> GetScins(string data,bool isStickersNeed)
        {
            data = File.ReadAllText("C:\\Users\\Odin\\Desktop\\sss.txt");
            List<MarketCheckerScin> scins = new List<MarketCheckerScin>();
            
            string[] dataSp = data.Split(new[] { "Купить" }, StringSplitOptions.None);
  
            foreach  (string item in dataSp.Skip(1))
            {
                string[] vs = item.Split('\n');
                MarketCheckerScin tmpScin = new MarketCheckerScin();
                //MessageBox.Show(((vs.Length - 5) / 4).ToString());
                tmpScin.price = ConvertFloatToDouble(vs[1]); //1
                tmpScin.floatvalue = ConvertFloatToDouble(vs[4]); // 4
                tmpScin.paintseed = ConvertToInt(vs[5]); //5
                tmpScin.full_item_name = vs[3]; //3
                tmpScin.Name = vs[3].Split('(')[0];
                if (item.Contains("Наклейка") || isStickersNeed)
                {
                    List<Sticker> stickers = new List<Sticker>();

                    string[] stick = item.Split(new[] { "Наклейка" }, StringSplitOptions.None);
                    
                    foreach(string st in stick.Skip(1))
                    {
                        Sticker sticker = new Sticker();
                        string[] cs1 = st.Split('\n');
                        sticker.name = ("Наклейка" + cs1[0]).Replace('\r',' ');
                        //TODO : Добавить поле износа в класс наклейки
                        //sticker.wear = cs1[3];
                        stickers.Add(sticker);
                    }

                    tmpScin.stickers = stickers.ToArray();
                }

                scins.Add(tmpScin);
            }
           



            return scins;
        }

        public static List<MarketCheckerScin> GetStickerPrice(List<MarketCheckerScin> scins)
        {
            for (int i = 0; i < scins.Count; i++)
            {
                if(scins[i].stickers!=null)
                {
                    for (int j = 0; j < scins[i].stickers.Length; j++)
                    {
                        scins[i].stickers[j].price = InventoryHandler.GetPrice2(scins[i].stickers[j].name);
                    }
                }
            }
            return scins;
        }

        public static List<MarketCheckerScin> CheckPaintSeed(List<MarketCheckerScin> scins, string name)
        {
            List<MarketCheckerScin> checkerScins = new List<MarketCheckerScin>();
            List<RariryPainSeed> seeds = RarityPaintSeedsHandler.seeds[name];
            

            for (int i = 0; i < scins.Count; i++)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if(seeds[j].Seeds.Contains(scins[i].paintseed))
                    {
                        scins[i].RariryPainSeed = seeds[j];
                        checkerScins.Add(scins[i]);
                    }
                }
            }


            return checkerScins;
        }

        public static List<MarketCheckerScin> GetScinsWithSticker(List<MarketCheckerScin> scins)
        {
            List<MarketCheckerScin> checkerScins = new List<MarketCheckerScin>();



            for (int i = 0; i < scins.Count; i++)
            {
                if(scins[i].stickers != null)
                {
                    checkerScins.Add(scins[i]);
                }
            }


            return checkerScins;
        }

        public static double GetAllStickerPrice(Scin scin)
        {
            if(scin.stickers==null) return 0.0;
            double price = 0.0;
            for (int i = 0; i < scin.stickers.Length; i++)
            {
                price += scin.stickers[i].price;
            }
            return price;
        }


        private static double ConvertFloatToDouble(string Float)
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

        private static int ConvertToInt(string Float)
        {
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
