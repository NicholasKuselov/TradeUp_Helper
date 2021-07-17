﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;
using TradeUpHelper.Controllers.MarketChecker;
using TradeUpHelper.Models;
using TradeUpHelper.Models.MarketChecker;
using TradeUpHelper.ViewModels;

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            DataContext = new MainWindowVM();
            this.SourceInitialized += new EventHandler(Window1_SourceInitialized);
        }

        void Window1_SourceInitialized(object sender, EventArgs e)
        {
            WindowSizing.WindowInitialized(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DEBUG.TEST();

            Updater.CheckUpdateSilence();
            ((MainWindowVM)DataContext).LoadInventory();
            if (SettingController.IsFirstStartAfterUpdate)
            {
                new ChangeLogWindow().Show();
                SettingController.IsFirstStartAfterUpdate = false;
            }

            TradeUpHelperAPI.FirstStart(DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), (string)Application.Current.Resources["Version"]);
           // MessageBox.Show(Assembly.GetExecutingAssembly().Location.Replace("TradeUpHelper.exe", ""));
            if (SettingController.IsFirstStart || true)
            {
   //             TradeUpHelperAPI.FirstStart(DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString(), (string)Application.Current.Resources["Version"]);
                SettingController.IsFirstStart = false;
            }
            //TODO : Добавить проверку на наличие инета при запуске проги

            PriceHandler.Load();
        }



        private void TopBar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
                else this.WindowState = WindowState.Maximized;
            }
        }
    }
}
