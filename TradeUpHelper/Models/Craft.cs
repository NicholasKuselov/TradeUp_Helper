using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TradeUpHelper.Models
{
    class Craft
    {

        public string date { get; set; } = "";
        public double price { get; set; } = 0.0;
        public double outcomePrice { get; set; } = 0.0;
        public double resFloat { get; set; } = 0.0;
        public int rarity { get; set; } = 0;
        public string outcomeName { get; set; } = "";

        public string imageUrl { get; set; } = "";

        public string getDirtProfit
        {
            get
            {
                return (outcomePrice - price).ToString();
            }
        }

        public string getClearProfit
        {
            get
            {
                return ((outcomePrice * 0.87) - price).ToString();
            }
        }

        [JsonIgnore]
        public string getName
        {

            get
            {
                return outcomeName.Split('(')[0];
            }
        }


        public Craft(double price, double outcomePrice, double resFloat, string date)
        {
            this.price = price;
            this.outcomePrice = outcomePrice;
            this.resFloat = resFloat;
            this.date = date;
            rarity = 0;
            outcomeName = "";
        }



    }
}
