using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;
using TradeUpHelper.Models.TradeUpHelperAPI;

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

        public static void Check()
        {
            if (ProgramKeyHandler.Key.Length <= 0 && SettingController.IsFirstStart)
            {
                ResponseRegisterProgram responseRegisterProgram = TradeUpHelperAPI.RegisterProgram();
                if (responseRegisterProgram.error)
                {
                    MessageBox.Show((string)Application.Current.Resources["ErrorServerDissable"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                    PriceHandler.Load();
                    return;
                }
                else
                {
                    MessageBox.Show((string)Application.Current.Resources["MessageProgramRegistredSuccessful"], (string)Application.Current.Resources["MessageTitle"], MessageBoxButton.OK, MessageBoxImage.Information);
                    ProgramKeyHandler.SetKey(responseRegisterProgram.key);
                }
            }
            else if (ProgramKeyHandler.Key.Length <= 0 && SettingController.IsFirstStartAfterUpdate)
            {
                ResponseRegisterProgram responseRegisterProgram = TradeUpHelperAPI.RegisterProgram();
                if (responseRegisterProgram.error)
                {
                    MessageBox.Show((string)Application.Current.Resources["ErrorServerDissable"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                    PriceHandler.Load();
                    return;
                }
                else
                {
                    MessageBox.Show((string)Application.Current.Resources["MessageProgramRegistredSuccessful"], (string)Application.Current.Resources["MessageTitle"], MessageBoxButton.OK, MessageBoxImage.Information);
                    ProgramKeyHandler.SetKey(responseRegisterProgram.key);
                }
            }
            else if (ProgramKeyHandler.Key.Length <= 0)
            {

                MessageBox.Show((string)Application.Current.Resources["ErrorEmptyKey"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.MainWindow.Close();
                return;
            }
            else
            {
                ResponseCheckProgramKey response = TradeUpHelperAPI.CheckProgramKey(ProgramKeyHandler.Key);
                if (!response.access)
                {
                    MessageBox.Show((string)Application.Current.Resources["ErrorWrongKey"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                    App.Current.MainWindow.Close();
                    return;
                }
            }

        }
    }
}
