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

        public bool IsBlueThemeActive { get; set; } = false;
        public bool IsPurpleThemeActive { get; set; } = false;
        public bool IsBlackThemeActive { get; set; } = false;

        public bool IsRusActive { get; set; } = false;
        public bool IsEngActive { get; set; } = false;
        public SettingWindowVM()
        {
            switch (App.Color)
            {
                case Themes.BLUE:
                    IsBlueThemeActive = true;
                    break;
                case Themes.PURPLE:
                    IsPurpleThemeActive = true;
                    break;
                case Themes.BLACK:
                    IsBlackThemeActive = true;
                    break;
                default:
                    break;
            }

            switch (App.Language)
            {
                case Languages.ENG:
                    IsEngActive = true;
                    break;
                case Languages.RUS:
                    IsRusActive = true;
                    break;
                default:
                    break;
            }
        }

        public ICommand SetRusLanguage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Language = Languages.RUS;
                });
            }
        }

        public ICommand SetEngLanguage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Language = Languages.ENG;
                });
            }
        }

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

        public ICommand SetDarkTheme
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Color = Themes.BLACK;
                });
            }
        }

        public ICommand SaveSettings
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (!SteamInventoryURL.Equals(SettingController.UserInventoryURL))
                    {
                        SettingController.UserInventoryURL = SteamInventoryURL;
                    }
                });
            }
        }
    }
}
