using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;
using TradeUpHelper.ViewModels;
using TradeUpHelper.Views;

namespace TradeUpHelper
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public App() => AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Exception);
        //static void Exception(object sender, UnhandledExceptionEventArgs args)
        //{

        //}
        public static PreviewWindow previewWindow;

        public App()
        {
            previewWindow = new PreviewWindow();
            previewWindow.Show();
            InitializeComponent();
            Color = TradeUpHelper.Properties.Settings.Default.Theme;
            Language = TradeUpHelper.Properties.Settings.Default.Language;
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
    }
}
