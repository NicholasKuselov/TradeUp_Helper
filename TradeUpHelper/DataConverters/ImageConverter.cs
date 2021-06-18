using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.DataConverters
{
    class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {
                if (System.Convert.ToString(value) == "") return null;
                return WebController.GetImageByURL(System.Convert.ToString(value));
            }
            catch (Exception)
            {
                return null;
            }

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
