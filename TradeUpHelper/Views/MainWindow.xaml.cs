using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;
using TradeUpHelper.Controllers.MarketChecker;
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
            Updater.CheckUpdateSilence();
            ((MainWindowVM)DataContext).LoadInventory();

            Dictionary<string, List<RariryPainSeed>> seeds = new Dictionary<string, List<RariryPainSeed>>();
            //List<RariryPainSeed> ttt = new List<RariryPainSeed>();
            //RariryPainSeed sss = new RariryPainSeed();
            //sss.Name = "test";
            //sss.Seeds = new[] { 12, 13, 14, 15 };
            //ttt.Add(sss);
            //RariryPainSeed yyy = new RariryPainSeed();
            //yyy.Name = "test2";
            //yyy.Seeds = new[] { 457, 235, 234, 876 };
            //ttt.Add(yyy);

            //seeds.Add("Glock | asassas", ttt);
            //seeds.Add("Glock | qqqqqq", ttt);
            //string json = JsonSerializer.Serialize<Dictionary<string, List<RariryPainSeed>>>(seeds);
            //File.WriteAllText(FilePath.paintSeedsFilePath, json);
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
