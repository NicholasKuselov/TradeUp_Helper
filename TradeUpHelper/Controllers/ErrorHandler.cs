using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Constants;

namespace TradeUpHelper.Controllers
{
    class ErrorHandler
    {
        public static void WriteErrorLog(Exception e, string where)
        {          
            File.WriteAllText(FilePath.ERROR_LOG_DIRECTORY + CreateLogName(DateTime.Now.ToString()) + ".txt","MESSAGE : \n" + e.GetBaseException().Message + "\nTRACE : \n" + e.GetBaseException().StackTrace + "\nSource :\n"+ e.GetBaseException().Source + "\nWhere :\n" + where);
            if (SettingController.IsSendErrorLog)
            {
                TradeUpHelperAPI.AddErrorLog(e.GetBaseException().Message, e.GetBaseException().StackTrace);
            }
        }

        public static void WriteErrorLog(Exception e)
        {
            File.WriteAllText(FilePath.ERROR_LOG_DIRECTORY + CreateLogName(DateTime.Now.ToString()) + ".txt", "MESSAGE : \n" + e.GetBaseException().Message + "\nTRACE : \n" + e.GetBaseException().StackTrace + "\nSource :\n" + e.GetBaseException().Source);
            if (SettingController.IsSendErrorLog)
            {
                TradeUpHelperAPI.AddErrorLog(e.GetBaseException().Message, e.GetBaseException().StackTrace);
            }
        }

        private static string CreateLogName(string dateTime)
        {
            string name = "";
            for (int i = 0; i < dateTime.Length; i++)
            {
                if (Char.IsDigit(dateTime[i]))
                {
                    name += dateTime[i];
                }
                else
                {
                    name += "_";
                }
            }
            return name;
        }
        
        public static void ShowError(string title,string text)
        {
            UserMessagesController.AddMessageInQuerry(title, text);
            UserMessagesController.Show();
        }
    }
}
