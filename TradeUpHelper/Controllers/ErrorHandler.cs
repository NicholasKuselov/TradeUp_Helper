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
        public static void WriteErrorLog(Exception e)
        {          
            File.WriteAllText(FilePath.ERROR_LOG_DIRECTORY+DateTime.Now.ToString().Replace('.','_').Replace(':','_').Replace(' ','_')+".txt","MESSAGE : \n" + e.GetBaseException().Message + "\nTRACE : \n" + e.GetBaseException().StackTrace + "\nSource :\n"+ e.GetBaseException().Source);
            if (SettingController.IsSendErrorLog)
            {
                TradeUpHelperAPI.AddErrorLog(e.GetBaseException().Message, e.GetBaseException().StackTrace);
            }
        }
    }
}
