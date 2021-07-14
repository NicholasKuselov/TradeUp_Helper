using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradeUpHelper.Constants;
using TradeUpHelper.Models.MarketChecker;

namespace TradeUpHelper.Controllers.MarketChecker
{
    class RarityPaintSeedsHandler
    {
        public static List<RarityPainSeedScin> Scins = JsonSerializer.Deserialize<List<RarityPainSeedScin>>(File.ReadAllText(FilePath.paintSeedsFilePath));
    }
}
