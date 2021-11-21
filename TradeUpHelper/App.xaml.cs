using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;
using TradeUpHelper.Views;


namespace TradeUpHelper
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PreviewWindow previewWindow;
        static void Exception(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show("FATAL ERROR", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            ErrorHandler.WriteErrorLog((Exception)args.ExceptionObject,args.ExceptionObject.ToString());
        }
        public App()
        {
            previewWindow = new PreviewWindow();
            
            previewWindow.grid.Background = LoadPreviewBunner(TradeUpHelper.Properties.Settings.Default.Theme);
            previewWindow.Show();
            InitializeComponent();
            Color = TradeUpHelper.Properties.Settings.Default.Theme;
            Language = TradeUpHelper.Properties.Settings.Default.Language;
            Currency = CurrencyHandler.Currencies.FirstOrDefault(p => p.Name.Equals(TradeUpHelper.Properties.Settings.Default.Currency));
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Exception);
        }


        public static string Color
        {
            get
            {
                return TradeUpHelper.Properties.Settings.Default.Theme;
            }
            set
            {

                ResourceDictionary dict = new ResourceDictionary();
                switch (value)
                {
                    case "blue":
                        dict.Source = new Uri(String.Format("Resources/Colors/Colors.{0}.xaml", value), UriKind.Relative);
                        TradeUpHelper.Properties.Settings.Default.Theme = value;
                        break;
                    case "purple":
                        dict.Source = new Uri(String.Format("Resources/Colors/Colors.{0}.xaml", value), UriKind.Relative);
                        TradeUpHelper.Properties.Settings.Default.Theme = value;
                        break;
                    case Themes.BLACK:
                        dict.Source = new Uri(String.Format("Resources/Colors/Colors.{0}.xaml", value), UriKind.Relative);
                        TradeUpHelper.Properties.Settings.Default.Theme = value;
                        break;
                    default:
                        dict.Source = new Uri("Resources/Colors/Colors.xaml", UriKind.Relative);
                        TradeUpHelper.Properties.Settings.Default.Theme = "";
                        break;
                }
                TradeUpHelper.Properties.Settings.Default.Save();
                ResourceDictionary oldDict = Application.Current.Resources.MergedDictionaries.First(p => p.Source.OriginalString.StartsWith("Resources/Colors/Colors"));

                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                //4. Вызываем евент для оповещения всех окон.
                //LanguageChanged(Application.Current, new EventArgs());
            }
        }

        public static string Language
        {
            get
            {
                return TradeUpHelper.Properties.Settings.Default.Language;
            }
            set
            {

                ResourceDictionary dict = new ResourceDictionary();
                switch (value)
                {
                    case Languages.ENG:
                        dict.Source = new Uri(String.Format("Resources/Local/lang.{0}.xaml", value), UriKind.Relative);
                        TradeUpHelper.Properties.Settings.Default.Language = value;
                        break;
                    case Languages.RUS:
                        dict.Source = new Uri(String.Format("Resources/Local/lang.{0}.xaml", value), UriKind.Relative);
                        TradeUpHelper.Properties.Settings.Default.Language = value;
                        break;

                    default:
                        dict.Source = new Uri("Resources/Local/lang.xaml", UriKind.Relative);
                        TradeUpHelper.Properties.Settings.Default.Language = "";
                        break;
                }
                TradeUpHelper.Properties.Settings.Default.Save();
                ResourceDictionary oldDict = Application.Current.Resources.MergedDictionaries.First(p => p.Source.OriginalString.StartsWith("Resources/Local/lang"));

                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                //4. Вызываем евент для оповещения всех окон.
                //LanguageChanged(Application.Current, new EventArgs());
            }
        }

        public static CurrencyHandler.Currency Currency
        {
            get
            {
                return CurrencyHandler.Currencies.Find(p => p.Name.Equals(TradeUpHelper.Properties.Settings.Default.Currency));
            }
            set
            {

                ResourceDictionary dict = new ResourceDictionary();
                if(value.Name.Equals(CurrencyHandler.USD.Name))
                {
                    dict.Source = new Uri(String.Format("Resources/Currencies/Currency.{0}.xaml", value.Name), UriKind.Relative);
                    TradeUpHelper.Properties.Settings.Default.Currency = value.Name;
                }else if (value.Name.Equals(CurrencyHandler.UAH.Name))
                {
                    dict.Source = new Uri(String.Format("Resources/Currencies/Currency.{0}.xaml", value.Name), UriKind.Relative);
                    TradeUpHelper.Properties.Settings.Default.Currency = value.Name;
                }
                else if (value.Name.Equals(CurrencyHandler.RUB.Name))
                {
                    dict.Source = new Uri(String.Format("Resources/Currencies/Currency.{0}.xaml", value.Name), UriKind.Relative);
                    TradeUpHelper.Properties.Settings.Default.Currency = value.Name;
                }
                else
                {
                    dict.Source = new Uri("Resources/Currencies/Currency.USD.xaml", UriKind.Relative);
                    TradeUpHelper.Properties.Settings.Default.Currency = "";
                }
                    
                TradeUpHelper.Properties.Settings.Default.Save();
                ResourceDictionary oldDict = Application.Current.Resources.MergedDictionaries.First(p => p.Source.OriginalString.StartsWith("Resources/Currencies/Currency"));

                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
        }

        private static ImageBrush LoadPreviewBunner(string theme)
        {
            if (theme.Equals(Themes.BLACK))
            {
                ImageBrush imgBr = new ImageBrush();
                imgBr.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/TradeUpHelperBannerDark.png"));
                return imgBr;
            }
            else
            {
                ImageBrush imgBr = new ImageBrush();
                imgBr.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/TradeUpHelperBanner.png"));
                return imgBr;
            }
            
        }
    }
}
