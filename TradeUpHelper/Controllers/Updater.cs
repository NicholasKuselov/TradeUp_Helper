using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using TradeUpHelper.Constants;
using TradeUpHelper.Models;
using TradeUpHelper.Views;

namespace TradeUpHelper.Controllers
{
    class Updater
    {
        public static void checkUpdates()
        {

            if(!WebController.CheckConnection())
            {
                MessageBox.Show((string)Application.Current.Resources["NetworkDisable"]);
                return;
            }

            XmlDocument docRemoteVersion = new XmlDocument();
            docRemoteVersion.Load(UpdatePath.VersionPathOnServer);

            XmlDocument docLocalVersion = new XmlDocument();
            docLocalVersion.LoadXml(File.ReadAllText("version.xml"));
            

            Version remoteVersion = new Version(docRemoteVersion.GetElementsByTagName("myprogram")[0].InnerText);
            Version localVersion = new Version(docLocalVersion.GetElementsByTagName("myprogram")[0].InnerText);
           
            if (localVersion < remoteVersion)
            {
                Update();
            }
            else
            {
                MessageBox.Show((string)Application.Current.Resources["UpdateNoVersion"], (string)Application.Current.Resources["bCheckUpdate"], MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private static void Update()
        {
            UpdateWindow updateWindow = new UpdateWindow(GetUpdateLog());
            if (updateWindow.ShowDialog() == false) return;
            try
            {
                if (File.Exists("TradeUpHelper.update")) { File.Delete("TradeUpHelper.update"); }
                Download();

            }
            catch (Exception)
            {
                if (File.Exists("TradeUpHelper.update")) { File.Delete("TradeUpHelper.update"); }
                Download();
            }
        }

        private static ChangeLogEntry GetUpdateLog()
        {
            ChangeLogEntry changeLogEntry;
            XmlSerializer formatter = new XmlSerializer(typeof(ChangeLogEntry));

            using (FileStream fs = new FileStream(FilePath.ChangeLogFilePath, FileMode.OpenOrCreate))
            {
                changeLogEntry = (ChangeLogEntry)formatter.Deserialize(fs);
            }

            return changeLogEntry;
        }

        private static void Download()
        {
            try
            {
                if (File.Exists("TradeUpHelper.update")) { File.Delete("TradeUpHelper.update"); }

                WebClient client = new WebClient();
                // client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(download_Completed);
                client.DownloadFileAsync(new Uri(UpdatePath.ProgramUpdateOnServer), "TradeUpHelper.update");

            }
            catch (Exception) { }
        }

        private static void download_Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                using (WebClient wb = new WebClient())
                {
                    File.WriteAllText("version.xml", wb.DownloadString(UpdatePath.VersionPathOnServer));
                }

                SettingController.IsFirstStartAfterUpdate = true;
                //Process.Start("updater.exe", "TradeUpHelper.update TradeUpHelper.exe");
                Process.Start("updater.exe", Assembly.GetExecutingAssembly().Location.Replace("TradeUpHelper.exe", "").Replace(" ","|"));
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erroe with updating main exe`s");
                File.WriteAllText("ErrorTradeUp.txt", ex.Message);
                File.WriteAllText("ErrorTradeUpTrace.txt", ex.StackTrace);
            }
            //try
            //{
            //    Process.Start("updater/updater.exe", "TradeUpHelper.update TradeUpHelper.exe");
            //    Process.GetCurrentProcess().Kill();
            //}
            //catch (Exception) { }
        }

        public static void CheckUpdateSilence()
        {
            if (!WebController.CheckConnection())
            {
                return;
            }

            XmlDocument docRemoteVersion = new XmlDocument();
            docRemoteVersion.Load(UpdatePath.VersionPathOnServer);

            XmlDocument docLocalVersion = new XmlDocument();
            docLocalVersion.LoadXml(File.ReadAllText("version.xml"));

            Version remoteVersion = new Version(docRemoteVersion.GetElementsByTagName("myprogram")[0].InnerText);
            Version localVersion = new Version(docLocalVersion.GetElementsByTagName("myprogram")[0].InnerText);

            if (localVersion < remoteVersion)
            {
                Update();
            }

        }
    }
}
