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
using TradeUpHelper.Controllers;

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        public FeedbackWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tbFeedBack.Text.Length > 2)
            {
                try
                {
                    TradeUpHelper.Constants.TradeUpHelperAPI.AddFeedback(tbFeedBack.Text);
                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteErrorLog(ex);
                }
            }
        }
    }
}
