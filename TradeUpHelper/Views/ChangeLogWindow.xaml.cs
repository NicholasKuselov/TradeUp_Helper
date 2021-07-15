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
using System.Windows.Shapes;

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для ChangeLogWindow.xaml
    /// </summary>
    public partial class ChangeLogWindow : Window
    {
        string text;
        public ChangeLogWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            this.Title = ((string)Application.Current.Resources["bChangeLog"]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //text = ((string)Application.Current.Resources["ChangeLog"]).Replace('|', '\n').Replace('/', ' ');
            //tb_changeLog.Text = text.Split('%').Last();

            //sv_changeLog.ScrollToEnd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
