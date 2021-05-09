using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Constants
{
    class UpdatePath
    {
        public static string VersionPathOnServer { get; } = "http://b80994.hostua01.fornex.org/TradeUpHelper/version.xml";
        public static string ProgramPathOnServer { get; } = "http://b80994.hostua01.fornex.org/TradeUpHelper/TradeUpHelper.exe";

        public static string ProgramDirectoryPathOnServer { get; } = "http://b80994.hostua01.fornex.org/TradeUpHelper/";
    }
}
