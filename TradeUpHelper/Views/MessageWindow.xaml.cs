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
using TradeUpHelper.Models.TradeUpHelperAPI;
using TradeUpHelper.ViewModels;

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            this.Title = ((string)Application.Current.Resources["bChangeLog"]);
        }

        public MessageWindow(List<MessageForUser> messages)
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            this.Title = ((string)Application.Current.Resources["bChangeLog"]);
            this.DataContext = new MessageWindowVM(messages);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserMessagesController.Clear();
            this.Close();
        }
    }
}
