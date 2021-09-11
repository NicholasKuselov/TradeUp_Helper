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
using System.Windows.Threading;
using System.Xml.Serialization;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;
using TradeUpHelper.Controllers.Cache;
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
    public partial class MainWindow : Window, IWinOwnerCollection
    {
        public List<Window> WinOwnerCollection { get; private set; }
        bool _shown;

        private Task PreviewWindowTask;
        public MainWindow()
        {
            InitializeComponent();

            WinOwnerCollection = new List<Window>();
            this.Closed += (sender, args) =>
            {
                PreviewWindowTask = null;
            };

            App.Current.MainWindow = this;

            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            DataContext = new MainWindowVM();
            //this.Hide();
            this.SourceInitialized += new EventHandler(Window1_SourceInitialized);
        }

        

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;

            UserMessagesController.Show();
        }

        private async void Window1_SourceInitialized(object sender, EventArgs e)
        {
            DEBUG.TEST();
            App.Current.MainWindow.Hide();
            this.Visibility = Visibility.Collapsed;
           // App.Current.MainWindow.Hide();
            ((PreviewWindowVM)App.previewWindow.DataContext).LoadStatus = (string)Application.Current.Resources["LSIsOnline"];
            await Task.Run(() =>
            {
                if (!WebController.CheckConnection())
                {
                    MessageBox.Show((string)Application.Current.Resources["ErrorNetworkDissableText"], (string)Application.Current.Resources["ErrorNetworkDissableTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                    App.Current.Shutdown();
                }
            });
            ((PreviewWindowVM)App.previewWindow.DataContext).LoadStatus = (string)Application.Current.Resources["LSCheckUpdates"];
            await Task.Run(() =>
            {
                Updater.CheckUpdateSilence();

            });

            ((PreviewWindowVM)App.previewWindow.DataContext).LoadStatus = (string)Application.Current.Resources["LSGetMessages"];
            await Task.Run(() =>
            {
                if (new UserMessagesFromAPIController().IsUnreadMessagesEnable())
                {
                    if (SettingController.IsFirstStart)
                    {
                        UserMessagesController.Clear();
                    }
                }

            });
            ((PreviewWindowVM)App.previewWindow.DataContext).LoadStatus = (string)Application.Current.Resources["LSCheckKey"];
            await Task.Run(() =>
            {
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

            });

            ((PreviewWindowVM)App.previewWindow.DataContext).LoadStatus = (string)Application.Current.Resources["LSLoadPrices"];


            await Task.Run(() =>
            {
                PriceHandler.Load();
            });

            ((PreviewWindowVM)App.previewWindow.DataContext).LoadStatus = (string)Application.Current.Resources["LSInventLoad"];

            await Task.Run(() =>
            {
                InventoryCacheController.Load();

            });

            App.previewWindow.Close();
            App.Current.MainWindow.Show();


            WindowSizing.WindowInitialized(this);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

    public interface IWinOwnerCollection
    {
        List<Window> WinOwnerCollection { get; }
    }
}
