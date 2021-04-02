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
                    if (_value > 0.0 && _value <= 0.07) return (string)Application.Current.Resources["WearFactoryNew"];
                    else if (_value > 0.07 && _value <= 0.15) return (string)Application.Current.Resources["WearMinimalWear"];
                    else if (_value > 0.15 && _value <= 0.38) return (string)Application.Current.Resources["WearFieldTested"];
                    else if (_value > 0.38 && _value <= 0.45) return (string)Application.Current.Resources["WearWellWorn"];
                    else if (_value > 0.45 && _value <= 1) return (string)Application.Current.Resources["WearBattleScared"];
                    else return "";
                }
                else
                {
                    if (_value > 0.0 && _value <= 0.07) return (string)Application.Current.Resources["WearFactoryNewShort"];
                    else if (_value > 0.07 && _value <= 0.15) return (string)Application.Current.Resources["WearMinimalWearShort"];
                    else if (_value > 0.15 && _value <= 0.38) return (string)Application.Current.Resources["WearFieldTestedShort"];
                    else if (_value > 0.38 && _value <= 0.45) return (string)Application.Current.Resources["WearWellWornShort"];
                    else if (_value > 0.45 && _value <= 1) return (string)Application.Current.Resources["WearBattleScaredShort"];
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
