using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Controllers
{
    class ContractStats
    {
        public static double GetPrice()
        {
            double price = 0.0;
            for (int i = 0; i < CraftHistoryHandler.crafts.Count; i++)
            {
                price += CraftHistoryHandler.crafts[i].price;
            }

            return price;
        }

        public static double GetOutcomePrice()
        {
            double price = 0.0;
            for (int i = 0; i < CraftHistoryHandler.crafts.Count; i++)
            {
                price += CraftHistoryHandler.crafts[i].outcomePrice;
            }

            return price;
        }

        public static double GetProfit()
        {
            double price = 0.0;

            for (int i = 0; i < CraftHistoryHandler.crafts.Count; i++)
            {
                price += CraftHistoryHandler.crafts[i].outcomePrice - CraftHistoryHandler.crafts[i].price - (CraftHistoryHandler.crafts[i].outcomePrice * 0.15);
            }

            return price%1000000.00;
        }
    }
}
