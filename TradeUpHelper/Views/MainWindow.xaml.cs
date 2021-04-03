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
using TradeUpHelper.Controllers;
using TradeUpHelper.ViewModels;

namespace TradeUpHelper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<TextBox> FloatTextBoxes; 
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            DataContext = new MainWindowVM();
            this.Title = "TradeUp Helper";
            this.SourceInitialized += new EventHandler(Window1_SourceInitialized);

            FloatTextBoxes = new List<TextBox>() { tb_float1, tb_float2, tb_float3, tb_float4, tb_float5, tb_float6, tb_float7, tb_float8, tb_float9, tb_float10};
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            border.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Updater.CheckUpdateSilence();
        }

        private void TopBar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
                else this.WindowState = WindowState.Maximized;
            }
        }

        private void tb_float_KeyUp(object sender, KeyEventArgs e)
        {
            int i = FloatTextBoxes.IndexOf((TextBox)sender);

            switch (e.Key)
            {
                case Key.Up:
                    if (i != 0 && i != -1)
                    {
                        FloatTextBoxes[i - 1].Focus();
                    }
                    break;
                case Key.Down:
                    if (i != 9 && i != -1)
                    {
                        FloatTextBoxes[i + 1].Focus();
                    }
                    break;
                case Key.Enter:
                    border.Focus();
                    break;
            }
        }

        private void tb_float_KeyDown(object sender, KeyEventArgs e)
        {
            int i = FloatTextBoxes.IndexOf((TextBox)sender);
            MessageBox.Show("Down "+i.ToString());
            
        }


    }

    
}



