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
using TradeUpHelper.ViewModels;

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для CraftHistoryWindow.xaml
    /// </summary>
    public partial class CraftHistoryWindow : Window
    {
        public CraftHistoryWindow()
        {
            InitializeComponent();
            this.DataContext = new CraftHistoryWindowVM();
        }
    }
}
