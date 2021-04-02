using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TradeUpHelper.Models;
using TradeUpHelper.ViewModels;

namespace TradeUpHelper
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
            this.Title = "TradeUp Helper";
            this.SourceInitialized += new EventHandler(Window1_SourceInitialized);
            //TopBar.MouseDoubleClick += new MouseButtonEventHandler(MaxizeButtonClick);
        }
        private void tb_float_TextChanged(object sender, TextChangedEventArgs e)
        {

            //if(tb_float1.Text.Length>2) ((MainWindowVM)DataContext).float1 = tb_float1.Text;
        }

        void Window1_SourceInitialized(object sender, EventArgs e)
        {
            WindowSizing.WindowInitialized(this);
        }

        void MaxizeButtonClick(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
            else this.WindowState = WindowState.Maximized;
        }
    }

    
}



