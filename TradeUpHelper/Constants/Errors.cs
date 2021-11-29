using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.Constants
{
    class Errors
    {
        public static readonly string ERROR = Translator.GetTextByKey("ErrorTitle");
        public static readonly string WRONG_INVENTORY_URL = Translator.GetTextByKey("ErrorWrongInventoryURL");

    }
}
