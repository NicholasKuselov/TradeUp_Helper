using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Controllers;
using TradeUpHelper.Models;

namespace TradeUpHelper.ViewModels
{
    class CraftHistoryWindowVM : ViewModelBase
    {
        public CraftHistoryWindowVM()
        {
            
        }

        public List<Craft> History { get; set; } = CraftHistoryHandler.crafts;

        public string profit { get; set; } = ContractStats.GetProfit().ToString();

        public string allPrice { get; set; } = ContractStats.GetPrice().ToString();

        public string allOutcomePrice { get; set; } = ContractStats.GetOutcomePrice().ToString();

        public string contractCount { get; set; } = CraftHistoryHandler.GetCraftCount().ToString();
    }
}
