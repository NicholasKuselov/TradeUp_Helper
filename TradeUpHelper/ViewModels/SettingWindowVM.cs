using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.ViewModels
{
    class SettingWindowVM : ViewModelBase
    {
        public string SteamInventoryURL { get; set; } = SettingController.UserInventoryURL;


        public ICommand SetBlueTheme
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Color = Themes.BLUE;
                });
            }
        }

        public ICommand SetPurpleTheme
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Color = Themes.PURPLE;
                });
            }
        }

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
