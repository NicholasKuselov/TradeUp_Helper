using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    class PriceDBLootFarm
    {
        public string name { get; set; }
        public int price { get; set; }
        public int have { get; set; }
        public int max { get; set; }
        public int rate { get; set; }
        public int tr { get; set; }
        public int res { get; set; }

        public double GetPrice { get { return price / 100.0; } }
    }
}
