using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Controllers
{
    public class CurrencyHandler
    {
        public static readonly List<Currency> Currencies;
        public static readonly Currency USD = new Currency(1,"USD");
        public static readonly Currency UAH = new Currency(18,"UAH");
        public static readonly Currency RUB = new Currency(5,"RUB");

        static CurrencyHandler()
        {
            Currencies = new List<Currency>() { USD, UAH, RUB };
        }

        public class Currency
        {
            public Currency(int code, string name)
            {
                Name = name;
                SteamCode = code;
            }
            public readonly int SteamCode;
            public readonly string Name;
        }
    }
}
