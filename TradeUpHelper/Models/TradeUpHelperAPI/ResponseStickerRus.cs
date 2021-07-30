using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models.TradeUpHelperAPI
{
    class ResponseStickerRus : Response
    {
        public Sticker[] stickers { get; set; }
        public class Sticker
        {
            public int idsticker { get; set; }
            public string name_eng { get; set; }
            public string name_rus { get; set; }
        }
    }
}
