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
        public static readonly Currency USD = new Currency(1,"USD",1);
        public static readonly Currency UAH = new Currency(18,"UAH",25);
        public static readonly Currency RUB = new Currency(5,"RUB",70);

        static CurrencyHandler()
        {
            Currencies = new List<Currency>() { USD, UAH, RUB };
        }

        public class Currency
        {
            public Currency(int code, string name, double exchangeRatesToUSD)
            {
                Name = name;
                SteamCode = code;
                ExchangeRatesToUSD = exchangeRatesToUSD;
            }
            public readonly int SteamCode;
            public readonly string Name;
            public readonly double ExchangeRatesToUSD;
        }
    }
}
