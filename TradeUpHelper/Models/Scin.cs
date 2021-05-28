using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    class Scin
    {
        public Scin()
        {

        }

        public Scin(Scin sc, string name, double pr)
        {
            Name = name;
            price = pr;
            quality = sc.quality;
            paintseed = sc.paintseed;
            imageurl = sc.imageurl;
            full_item_name = sc.full_item_name;
            // stickers = sc.stickers;

        }
        public string Name { get; set; }
        public int quality { get; set; }
        public double price { get; set; }
        public int paintseed { get; set; }
        public double floatvalue { get; set; }
        public string imageurl { get; set; }
        public string full_item_name { get; set; }
        // public Sticker[] stickers { get; set; }
        public int rarity { get; set; }

    }
}
