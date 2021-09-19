using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;
using TradeUpHelper.Controllers.Cache;
using TradeUpHelper.Models;
using TradeUpHelper.Views;

namespace TradeUpHelper.ViewModels
{
    class MainWindowVM : ViewModelBase, IMainWindow
    {
        private Page _CurrentPage;
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;
                if (value.Equals(MainMenuPage))
                {
                    IsBackButtonActive = Visibility.Hidden;
                }
                else
                {
                    IsBackButtonActive = Visibility.Visible;
                }
            }
        }
        public TradeUpPage TradeUpPage { get; set; }
        public InventoryPage InventoryPage { get; set; }
        private MainMenuPage MainMenuPage { get; set; }
        public MarketCheckerPage MarketCheckerPage { get; set; }

        public Visibility IsBackButtonActive { get; set; } = Visibility.Hidden;

        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    //if (MessageBox.Show("Tochno?", "Zakrit okno", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    //{
                    //    Application.Current.MainWindow.Close();
                    //}

                    Application.Current.MainWindow.Close();
                });

            }
        }

        public ICommand MaximizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    }

                });
            }
        }

        public ICommand MinimizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });
            }
        }

        public ICommand GoBackPageCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MainMenuPage = new MainMenuPage();
                    CurrentPage = MainMenuPage;
                });
            }
        }


        public ICommand ShowFeedbackWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new FeedbackWindow().Show();

                });
            }
        }
        public ICommand UpdateProgram
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Updater.checkUpdates();

                });
            }
        }

        public ICommand ShowChangeLog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new ChangeLogWindow().Show();
                    // MessageBox.Show(((string)Application.Current.Resources["ChangeLog"]).Replace('|', '\n').Replace('/',' '), (string)Application.Current.Resources["bChangeLog"], MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
        }

        public ICommand ShowSettingWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new SettingWindow().Show();
                });
            }
        }

        public ICommand ShowHelperSite
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Process.Start(WebPath.TradeUpHelperSite);
                });
            }
        }
        
        public MainWindowVM()
        {
            PageController.mainWindow = this;
            SettingController.Load();

            // InventoryPage = new InventoryPage();
            TradeUpPage = new TradeUpPage();
            MainMenuPage = new MainMenuPage();

            CurrentPage = MainMenuPage;


        }

        public void SelectTradeUpPage()
        {
            ((MainMenuPageVM)MainMenuPage.DataContext).StopScrollingNews();
            TradeUpPage = new TradeUpPage();
            CurrentPage = TradeUpPage;
        }

        public void SelectInventoryPage()
        {
            if (SettingController.UserInventoryURL.Length < 5)
            {
                MessageBox.Show((string)Application.Current.Resources["ErrorWithSteamInventoryURL"]);
                return;
            }
            CurrentPage = new InventoryPage();
        }


        public void SelectMarketCheckerPage()
        {
            MarketCheckerPage = new MarketCheckerPage();
            ((MainMenuPageVM)MainMenuPage.DataContext).StopScrollingNews();
            CurrentPage = MarketCheckerPage;
        }
    }
}
