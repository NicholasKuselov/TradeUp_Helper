using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TradeUpHelper.Models.TradeUpHelperAPI;

namespace TradeUpHelper.DataConverters
{
    class MessageTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {
                switch ((MessageForUser.MessageTypes)value)
                {
                    case MessageForUser.MessageTypes.Info:
                        return "/TradeUpHelper;component/Resources/Images/info.png";
                    case MessageForUser.MessageTypes.Warning:
                        return "/TradeUpHelper;component/Resources/Images/warning.png";
                    case MessageForUser.MessageTypes.Error:
                        return "/TradeUpHelper;component/Resources/Images/error.png";
                }
                return "/TradeUpHelper;component/Resources/Images/info.png";
            }
            catch (Exception)
            {
                return "/TradeUpHelper;component/Resources/Images/info.png";
            }

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
