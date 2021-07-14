using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Constants
{
    class UpdatePath
    {
        public static string VersionPathOnServer { get; } = "https://tradeuphelper-csgo.site/TradeUpHelperProgram/Updates/version.xml";
        public static string ProgramPathOnServer { get; } = "http://b80994.hostua01.fornex.org/TradeUpHelper/TradeUpHelper.exe";
        public static string ProgramUpdateOnServer { get; } = "https://tradeuphelper-csgo.site/TradeUpHelperProgram/Updates/LatestUpdate.update";
        public static string ProgramDirectoryPathOnServer { get; } = "http://b80994.hostua01.fornex.org/TradeUpHelper/";
    }
}
