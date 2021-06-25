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
        public static Dictionary<string, List<RariryPainSeed>> seeds = JsonSerializer.Deserialize<Dictionary<string, List<RariryPainSeed>>>(File.ReadAllText(FilePath.paintSeedsFilePath));
    }
}
