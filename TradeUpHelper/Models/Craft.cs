using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    class Craft
    {
        public double price { get; set; }
        public double outcomePrice { get; set; }
        public double resFloat { get; set; }

        public Craft(double price, double outcomePrice, double resFloat)
        {
            this.price = price;
            this.outcomePrice = outcomePrice;
            this.resFloat = resFloat;
        }

     
    }
}
