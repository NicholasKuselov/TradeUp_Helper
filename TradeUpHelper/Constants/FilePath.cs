using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Constants
{
    class FilePath
    {
        public static string CraftHistoryPath { get; } = "data/history.json";
        public static string settingFile { get; } = "data/setting.cfg";
        public static string inventoryCacheFile { get; } = "data/inventory.cch";
        public static string paintSeedsFilePath { get; } = "data/Seeds/seeds.sds";
        public static string userPaintSeedsFilePath { get; } = "data/Seeds/user_seeds.sds";
    }
}
