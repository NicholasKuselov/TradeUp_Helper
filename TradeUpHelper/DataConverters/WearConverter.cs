using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TradeUpHelper.DataConverters
{
    public class ShortWearConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double _value = System.Convert.ToDouble(value);

                if (parameter != null && parameter.ToString() == "long")
                {
                    if (_value > 0.0 && _value <= 0.07) return "Прямо с завода";
                    else if (_value > 0.07 && _value <= 0.15) return "Немного поношенное";
                    else if (_value > 0.15 && _value <= 0.38) return "После полевых испытаний";
                    else if (_value > 0.38 && _value <= 0.45) return "Поношенное";
                    else if (_value > 0.45 && _value <= 1) return "Закаленное в боях";
                    else return "";
                }
                else
                {
                    if (_value > 0.0 && _value <= 0.07) return "FN";
                    else if (_value > 0.07 && _value <= 0.15) return "MW";
                    else if (_value > 0.15 && _value <= 0.38) return "FT";
                    else if (_value > 0.38 && _value <= 0.45) return "WW";
                    else if (_value > 0.45 && _value <= 1) return "BS";
                    else return "";
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
