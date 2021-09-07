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
    /// Логика взаимодействия для PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        private MainWindow _winOwner;

        public PreviewWindow()
        {
            InitializeComponent();
        }

        public MainWindow WinOwner
        {
            get { return _winOwner; }
            set
            {
                _winOwner = value;
                if (value is IWinOwnerCollection)
                {
                    ((IWinOwnerCollection)value).WinOwnerCollection.Add(this);
                }
            }
        }
    }
}
