using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (System.Convert.ToDouble(value) == 0.0) return Brushes.Gray;
                double profit = System.Convert.ToDouble(value);
                
                if (profit>0)
                {
                    return Brushes.Green;
                }
                else
                {
                    return Brushes.Red;
                }
            }
            catch (Exception e)
            {
                return Brushes.Gray;
            }

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
