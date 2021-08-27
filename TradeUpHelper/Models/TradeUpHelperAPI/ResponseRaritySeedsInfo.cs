using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Controllers.MarketChecker;

namespace TradeUpHelper.Models.TradeUpHelperAPI
{
    class ResponseRaritySeedsInfo : Response
    {
        public List<RarityPainSeedScin> scins { get; set; }
    }
}
