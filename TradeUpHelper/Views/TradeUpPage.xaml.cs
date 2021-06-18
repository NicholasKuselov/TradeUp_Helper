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

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для TradeUpPage.xaml
    /// </summary>
    public partial class TradeUpPage : Page
    {
        private List<TextBox> FloatTextBoxes;
        private List<TextBox> PriceTextBoxes;
        public TradeUpPage()
        {
            InitializeComponent();
            DataContext = new TradeUpPageVM();
            this.Title = "TradeUp Helper";


            FloatTextBoxes = new List<TextBox>() { tb_float1, tb_float2, tb_float3, tb_float4, tb_float5, tb_float6, tb_float7, tb_float8, tb_float9, tb_float10 };
            PriceTextBoxes = new List<TextBox>() { tb_price1, tb_price2, tb_price3, tb_price4, tb_price5, tb_price6, tb_price7, tb_price8, tb_price9, tb_price10 };

            CraftHistoryHandler.Load();
        }
        private void tb_float_TextChanged(object sender, TextChangedEventArgs e)
        {

            //if(tb_float1.Text.Length>2) ((TradeUpPageVM)DataContext).float1 = tb_float1.Text;
        }


        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            border.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Updater.CheckUpdateSilence();
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
                case Key.Left:
                    if (i > 4 && i != -1)
                    {
                        PriceTextBoxes[i - 5].Focus();
                    }
                    break;
                case Key.Right:
                    if (i != -1)
                    {
                        PriceTextBoxes[i].Focus();
                    }
                    break;
                case Key.Enter:
                    border.Focus();
                    break;
            }
        }

        private void tb_price_KeyUp(object sender, KeyEventArgs e)
        {
            int i = PriceTextBoxes.IndexOf((TextBox)sender);

            switch (e.Key)
            {
                case Key.Up:
                    if (i != 0 && i != -1)
                    {
                        PriceTextBoxes[i - 1].Focus();
                    }
                    break;
                case Key.Down:
                    if (i != 9 && i != -1)
                    {
                        PriceTextBoxes[i + 1].Focus();
                    }
                    break;
                case Key.Left:
                    if (i != -1)
                    {
                        FloatTextBoxes[i].Focus();
                    }
                    break;
                case Key.Right:
                    if (i < 5 && i != -1)
                    {
                        FloatTextBoxes[i + 5].Focus();
                    }
                    break;
                case Key.Enter:
                    border.Focus();
                    break;
            }
        }
        private void tb_threshold_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    border.Focus();
                    break;
            }
        }

        private void tb_float_KeyDown(object sender, KeyEventArgs e)
        {
            int i = FloatTextBoxes.IndexOf((TextBox)sender);
            MessageBox.Show("Down " + i.ToString());

        }
    }
}
