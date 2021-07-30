using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradeUpHelper.Controllers;
using TradeUpHelper.Models.TradeUpHelperAPI;

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

        public static void AddSticekr(string NameEng, string NameRus)
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("NameEng", NameEng);
            param.Add("NameRus", NameRus);
            WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.AddSticker, param);
        }

        public static ResponseStickerRus GetStickerByRus(string NameRus)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("NameRus", NameRus);
            string response = WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.GetStickerByRus, param);
            return JsonSerializer.Deserialize<ResponseStickerRus>(response);
        }
    }
}
