using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.ViewModels
{
    class MainMenuPageVM : ViewModelBase
    {
        public ICommand OpenTradeUpWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    PageController.SelectTradeUpPage();
                });
            }
        }
    }
}
