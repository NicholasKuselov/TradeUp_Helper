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
    class RarityColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {
                if (System.Convert.ToInt32(value) == 0) return (Brush)Application.Current.Resources["Color_Rare_None"];
                double profit = System.Convert.ToDouble(value);

                switch (System.Convert.ToInt32(value))
                {
                    case 1:
                        return (Brush)Application.Current.Resources["Color_Rare_Consumer"];
                        break;
                    case 2:
                        return (Brush)Application.Current.Resources["Color_Rare_Industrial"];
                        break;
                    case 3:
                        return (Brush)Application.Current.Resources["Color_Rare_MilSpec"];
                        break;
                    case 4:
                        return (Brush)Application.Current.Resources["Color_Rare_Restricted"];
                        break;
                    case 5:
                        return (Brush)Application.Current.Resources["Color_Rare_Classified"];
                        break;
                    case 6:
                        return (Brush)Application.Current.Resources["Color_Rare_Covert"];
                        break;
                    default:
                        return (Brush)Application.Current.Resources["Color_Rare_None"];
                        break;
                }
            }
            catch (Exception e)
            {
                return (Brush)Application.Current.Resources["Color_Rare_None"];
            }

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
