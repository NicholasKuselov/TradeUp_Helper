using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TradeUpHelper.Models;

namespace TradeUpHelper.DataConverters
{
    public class ShortWearConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            try
            {
                if (System.Convert.ToDouble(value) == 0.0) return "";
                Wear wear = Wears.GetWearByFloat(System.Convert.ToDouble(value));
                if (parameter != null && parameter.ToString() == "long")
                {
                    return wear.LongName;
                }
                else
                {
                    return wear.ShortName;
                }
            }
            catch(Exception e)
            {
                return "";
            }
            
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
