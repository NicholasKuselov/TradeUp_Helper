using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TradeUpHelper.Controllers
{
    class Translator
    {
        public static string GetTextByKey(string key)
        {
            return (string)Application.Current.Resources[key];
        }
    }
}
