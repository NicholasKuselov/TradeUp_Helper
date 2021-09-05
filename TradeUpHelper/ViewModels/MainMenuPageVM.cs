using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradeUpHelper.Controllers;

namespace TradeUpHelper.ViewModels
{
    class MainMenuPageVM : ViewModelBase
    {
        public NewsHandler NewsHandler { get; set; }
        private int CurrentNewsIndex = 0;
        public string News { get; set; } = "";

        private bool isNewsScroll = true;
        public MainMenuPageVM()
        {
            NewsHandler = new NewsHandler();
            News = NewsHandler.News[0];

            Task.Run(() =>
            {
                while (isNewsScroll)
                {
                    NextNews();
                    Thread.Sleep(5000);
                    
                }
            });
        }

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

        public ICommand OpenInventoryPage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    //PageController.SelectInventoryPage();
                    App.Color = "purple";
                });
            }
        }
        public ICommand OpenMarketCheckerPage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    PageController.SelectMarketCheckerPage();
                });
            }
        }

        public ICommand GoNextNews
        {
            get
            {
                return new RelayCommand(() =>
                {
                    NextNews();
                });
            }
        }

        public ICommand GoBackNews
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CurrentNewsIndex == 0)
                    {
                        CurrentNewsIndex = NewsHandler.News.Count -1;
                        News = NewsHandler.News[CurrentNewsIndex];
                    }
                    else
                    {
                        CurrentNewsIndex--;
                        News = NewsHandler.News[CurrentNewsIndex];
                    }
                });
                
            }
        }

        private void NextNews()
        {
            if (CurrentNewsIndex < NewsHandler.News.Count - 1)
            {
                CurrentNewsIndex++;
                News = NewsHandler.News[CurrentNewsIndex];
            }
            else
            {
                CurrentNewsIndex = 0;
                News = NewsHandler.News[CurrentNewsIndex];
            }
        }

        public void StopScrollingNews()
        {
            isNewsScroll = false;
        }

    }
}
