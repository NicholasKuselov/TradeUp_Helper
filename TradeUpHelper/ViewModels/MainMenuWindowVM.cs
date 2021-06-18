using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TradeUpHelper.ViewModels
{
    class MainMenuWindowVM : ViewModelBase
    {
        private readonly MainWindow tradeUpWindow = new MainWindow();
        
        public ICommand OpenTradeUpWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    tradeUpWindow.Show();
                });
            }
        }
    }
}
