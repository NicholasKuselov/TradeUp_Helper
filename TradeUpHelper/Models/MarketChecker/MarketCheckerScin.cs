using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TradeUpHelper.Models.MarketChecker
{
    class MarketCheckerScin : Scin
    {
        public double MinPrice { get; set; } = 0;
        
        public double OverPrice { get { return price - MinPrice; } }

        public RariryPainSeed RariryPainSeed { get; set; }

        public int Index { get; set; } = 0;

        public string GetStickers { get
            {
                if (stickers == null) return "";
                string tmp = "";
                for (int i = 0; i < stickers.Length; i++)
                {
                    tmp += stickers[i].name + " " + stickers[i].price + (string)Application.Current.Resources["CurrencyIco"];
                    if (i != stickers.Length - 1) tmp += "\n";
                }
                return tmp;
            } }

        public string GetStickersPrice { get
            {
                if (stickers == null) return "";
                double tmp = 0.0;
                for (int i = 0; i < stickers.Length; i++)
                {
                    if(stickers[i].price>0)
                    tmp += stickers[i].price;
                }
                return tmp.ToString();
            } }
    }
}
