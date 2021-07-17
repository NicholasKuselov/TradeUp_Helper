using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.Constants
{
    class TradeUpHelperAPI
    {
        private static string baseApiPath = "https://tradeuphelper-csgo.site/API/API.php?apicall=";

        public static void FirstStart(string date,string version)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("StartDate", date);
            param.Add("HelperVersion", version);
            WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.FirstStart, param);
        }
    }
}
