using System;
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
using TradeUpHelper.Models.TradeUpHelperAPI;
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
            if (!WebController.CheckConnection())
            {
                MessageBox.Show((string)Application.Current.Resources["ErrorNetworkDissableText"], (string)Application.Current.Resources["ErrorNetworkDissableTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.Shutdown();
            }
            Updater.CheckUpdateSilence();
            ((MainWindowVM)DataContext).LoadInventory();

            if (new UserMessagesFromAPIController().IsUnreadMessagesEnable())
            {
                UserMessagesController.Show();
            }
            
            

            ProgramKeyHandler.Load();
            ProgramKeyHandler.Check();
            
            if (SettingController.IsFirstStartAfterUpdate)
            {
                new ChangeLogWindow().Show();
                SettingController.IsFirstStartAfterUpdate = false;
            }

            if (SettingController.IsFirstStart)
            {
                TradeUpHelperAPI.FirstStart(DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), (string)Application.Current.Resources["Version"], ProgramKeyHandler.Key);
                SettingController.IsFirstStart = false;
            }

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
