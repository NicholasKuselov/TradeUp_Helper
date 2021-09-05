using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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


		public App()
		{
			InitializeComponent();

			Color = TradeUpHelper.Properties.Settings.Default.Theme;
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
	}
}
