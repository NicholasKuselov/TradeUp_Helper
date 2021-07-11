using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.ViewModels
{
    class SettingWindowVM : ViewModelBase
    {
        public string SteamInventoryURL { get; set; } = "";

        public ICommand SaveSettings
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SettingController.UserInventoryURL = SteamInventoryURL;
                });
            }
        }
    }
}
