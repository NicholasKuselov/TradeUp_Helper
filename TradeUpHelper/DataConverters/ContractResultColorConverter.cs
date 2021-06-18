using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TradeUpHelper.DataConverters
{
    class ContractResultColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {
                if (System.Convert.ToDouble(value) == 0.0) return (Brush)Application.Current.Resources["Color_ContractFail"];
                double profit = System.Convert.ToDouble(value);
                
                if (profit>0)
                {
                    return (Brush)Application.Current.Resources["Color_ContractSuccess"];
                }
                else
                {
                    return (Brush)Application.Current.Resources["Color_ContractFail"];
                }
            }
            catch (Exception)
            {
                return (Brush)Application.Current.Resources["Color_ContractFail"];
            }

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
