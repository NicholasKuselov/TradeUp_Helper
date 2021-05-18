using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TradeUpHelper.Models
{
    class Craft
    {

        public string date { get; set; }
        public double price { get; set; }
        public double outcomePrice { get; set; }
        public double resFloat { get; set; }
        public Rarity rarity { get; set; }
        public string outcomeName { get; set; }

        public string getDirtProfit
        {
            get
            {
                return (outcomePrice - price).ToString();
            }
        }


        public Brush getResultColor
        {
            get
            {
                if ((outcomePrice - price) < 0) return Brushes.Red;
                else if ((outcomePrice - price) > 0) return Brushes.Green;
                else return Brushes.Gray;
            }
        }

        public Craft(double price, double outcomePrice, double resFloat, string date)
        {
            this.price = price;
            this.outcomePrice = outcomePrice;
            this.resFloat = resFloat;
            this.date = date;
            rarity = null;
            outcomeName = "";
        }



    }
}
