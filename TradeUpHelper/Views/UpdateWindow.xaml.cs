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
using TradeUpHelper.Models;
using TradeUpHelper.ViewModels;

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        UpdateWindowVM windowVM;
        public UpdateWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            windowVM = new UpdateWindowVM();
            this.DataContext = windowVM;
        }

        public UpdateWindow(ChangeLogEntry changeLog)
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            windowVM = new UpdateWindowVM(changeLog);
            this.DataContext = windowVM;
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            try
            {
                ((UpdateWindowVM)DataContext).SetNNIcon();
            }
            catch(StackOverflowException ex)
            {
                ((UpdateWindowVM)DataContext).UpdateIcoPath = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
