using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;

namespace TradeUpHelper.Controllers
{
    class ProgramKeyHandler
    {
        public static string Key { get; set; }
        public static string Load()
        {
            try
            {
                Key = File.ReadAllText(FilePath.ProgramKeyFile);
                return Key;
            }
            catch
            {
                MessageBox.Show((string)Application.Current.Resources["ErrorEmptyKey"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                Key = "";
                File.WriteAllText(FilePath.ProgramKeyFile, Key);
                return Key;
            }
        }

        public static void SetKey(string key)
        {
            Key = key;
            File.WriteAllText(FilePath.ProgramKeyFile, key);
        }
    }
}
