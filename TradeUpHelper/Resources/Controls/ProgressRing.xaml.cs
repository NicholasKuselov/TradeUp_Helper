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

namespace TradeUpHelper.Resources.Controls
{
    /// <summary>
    /// Логика взаимодействия для ProgressRing.xaml
    /// </summary>
    public partial class ProgressRing : UserControl
    {
        public ProgressRing()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public static readonly DependencyProperty TextProperty =
                   DependencyProperty.Register(
                         "CaptionText",
                          typeof(string),
                          typeof(ProgressRing));

        public string CaptionText
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public bool IsRotate { get; set; }
        public int TextFontSize { get; set; }
    }
}
