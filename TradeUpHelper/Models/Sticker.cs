using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    class Sticker
    {
        public int stickerId { get; set; }
        public string name { get; set; }
        public int slot { get; set; }

        public double price { get; set; } = -2.0;
    }
}
