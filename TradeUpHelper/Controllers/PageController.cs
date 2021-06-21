using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TradeUpHelper.Models;
using TradeUpHelper.Views;

namespace TradeUpHelper.Controllers
{
    class PageController : ViewModelBase
    {
        public static IMainWindow mainWindow;

        public static void SelectTradeUpPage()
        {
            mainWindow.SelectTradeUpPage();
        }

        public static void SelectInventoryPage()
        {
            mainWindow.SelectInventoryPage();
        }
    }
}
