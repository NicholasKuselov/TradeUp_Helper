using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TradeUpHelper.Models.MarketChecker;

namespace TradeUpHelper.Controllers.MarketChecker
{
    class RarityPainSeedScin
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public List<RariryPainSeed> Seeds {get;set;}

        
    }
}
