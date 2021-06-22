using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.Models.Cache
{
    class InventoryCache
    {
        public List<Scin> Scins { get; set; } = InventoryHandler.items;
        public string LoadDate = DateTime.Now.ToString();
    }
}
