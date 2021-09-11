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

        public static void FirstStart(string date,string version,string key)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("StartDate", date);
            param.Add("HelperVersion", version);
            param.Add("Key", key);
            WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.FirstStart, param);
        }

        public static void AddSticekr(string NameEng, string NameRus)
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("NameEng", NameEng);
            param.Add("NameRus", NameRus);
            WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.AddSticker, param);
        }

        public static void AddErrorLog(string message, string stacktrace)
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("message", message);
            param.Add("stacktrace", stacktrace);
            param.Add("key", ProgramKeyHandler.Key);
            WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.AddErrorLog, param);
        }

        public static void AddFeedback(string text)
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("text", text);
            param.Add("key", ProgramKeyHandler.Key);
            WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.AddFeedback, param);
        }

        public static ResponseStickerRus GetStickerByRus(string NameRus)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("NameRus", NameRus);
            string response = WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.GetStickerByRus, param);
            return JsonSerializer.Deserialize<ResponseStickerRus>(response);
        }

        public static ResponseRegisterProgram RegisterProgram()
        {
            string response = WebController.SendGet(baseApiPath + TradeUpHelperAPICalls.RegisterProgram);
            return JsonSerializer.Deserialize<ResponseRegisterProgram>(response);
        }

        public static ResponseCheckProgramKey CheckProgramKey(string key)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("key", key);
            string response = WebController.SendPost(baseApiPath + TradeUpHelperAPICalls.CheckProgramKey, param);
            return JsonSerializer.Deserialize<ResponseCheckProgramKey>(response);
        }

        public static ResponseRaritySeedsInfo GetRaritySeeds()
        {
            string response = WebController.SendGet(baseApiPath + TradeUpHelperAPICalls.GetRarityPaintSeeds);
            return JsonSerializer.Deserialize<ResponseRaritySeedsInfo>(response);
        }

        public static ResponseMessagesForUsers GetMessagesForUser()
        {
            string response = WebController.SendGet(baseApiPath + TradeUpHelperAPICalls.GetUserMessages);
            return JsonSerializer.Deserialize<ResponseMessagesForUsers>(response);
        }
    }
}
