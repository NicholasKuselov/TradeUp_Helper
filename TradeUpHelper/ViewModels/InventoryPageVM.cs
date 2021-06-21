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
    class InventoryPageVM : ViewModelBase
    {
        public List<Scin> Scins { get; set; } = InventoryHandler.items;
    }
}
