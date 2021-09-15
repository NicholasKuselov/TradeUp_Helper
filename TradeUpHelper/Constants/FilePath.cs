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
        public static string ProgramKeyFile { get; } = "data/key";
        public static string ChangeLogFilePath { get; } = "data/changeLog.xml";
        public const string ERROR_LOG_DIRECTORY = "data/logs/errorLog";

        public const string LOOTFARM_PRICE_CACHE = "data/cache/lootfarmprice.json";
        public const string STEAM_PRICE_CACHE = "data/cache/steamprice.json";
    }
}
