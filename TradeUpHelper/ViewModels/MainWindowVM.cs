using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TradeUpHelper.Controllers;
using TradeUpHelper.Models;
using TradeUpHelper.Views;

namespace TradeUpHelper.ViewModels
{
    class MainWindowVM : ViewModelBase, IMainWindow
    {
        public Page CurrentPage { get; set; }
        public TradeUpPage TradeUpPage { get; set; }
        private MainMenuPage MainMenuPage { get; set; }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (MessageBox.Show("Tochno?", "Zakrit okno", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Application.Current.MainWindow.Close();
                    }


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

        public MainWindowVM()
        {
            PageController.mainWindow = this;
            TradeUpPage = new TradeUpPage();
            MainMenuPage = new MainMenuPage();

            CurrentPage = MainMenuPage;
        }

        public void SelectTradeUpPage()
        {
            CurrentPage = TradeUpPage;
        }
    }
}
