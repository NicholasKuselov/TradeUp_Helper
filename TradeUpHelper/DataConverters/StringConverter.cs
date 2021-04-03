using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.DataConverters
{
    class StringConverter
    {
        public static double ConvertStringToDouble(string str)
        {
            str = str.Replace('.', ',');
            string newStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]) || str[i].Equals(','))
                {
                    newStr = newStr + str[i];
                }
            }
            if (newStr.Length == 0) return 0.0;
            return Convert.ToDouble(newStr);
        }
    }
}
