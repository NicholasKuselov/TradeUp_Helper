using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using TradeUpHelper.Constants;

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
            Version minVersionForUpdate = new Version(docRemoteVersion.GetElementsByTagName("min_version_for_update")[0].InnerText);

            if (minVersionForUpdate > localVersion)
            {
                MessageBox.Show((string)Application.Current.Resources["ErrorWithMinVersionForUpdate"], (string)Application.Current.Resources["bCheckUpdate"], MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
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
            if (MessageBoxResult.No.Equals(MessageBox.Show((string)Application.Current.Resources["UpdateNewVersion"], (string)Application.Current.Resources["bCheckUpdate"], MessageBoxButton.YesNo, MessageBoxImage.Information))) return;
            try
            {
                DownloadNewDll();
                if (File.Exists("TradeUpHelper.update")) { File.Delete("TradeUpHelper.update"); }
                Download();

            }
            catch (Exception)
            {
                if (File.Exists("TradeUpHelper.update")) { File.Delete("TradeUpHelper.update"); }
                Download();
            }
        }

        private static void DownloadNewDll()
        {
            XmlDocument docRemoteVersion = new XmlDocument();
            docRemoteVersion.Load(UpdatePath.VersionPathOnServer);

            string tmp = docRemoteVersion.GetElementsByTagName("new_files")[0].InnerText;
            if (tmp == "") return;


            List<string> vs = new List<string>(tmp.Split(' '));
            try
            {
                for (int i = 0; i < vs.Count; i++)
                {
                    if (File.Exists(vs[i])) { File.Delete(vs[i]); }
                    WebClient client = new WebClient();
                    // client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    //client.DownloadFileCompleted += new AsyncCompletedEventHandler(download_Completed);
                    client.DownloadFileAsync(new Uri(UpdatePath.ProgramDirectoryPathOnServer + vs[i]), vs[i]);
                }
                

            }
            catch (Exception) { MessageBox.Show("erroe with downloading new dlls"); }
        }

        private static void Download()
        {
            try
            {
                if (File.Exists("TradeUpHelper.update")) { File.Delete("TradeUpHelper.update"); }

                WebClient client = new WebClient();
                // client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(download_Completed);
                client.DownloadFileAsync(new Uri(UpdatePath.ProgramPathOnServer), "TradeUpHelper.update");

            }
            catch (Exception) { }
        }

        //private void download_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    try
        //    {
        //        //progressBar1.Value = e.ProgressPercentage;
        //    }
        //    catch (Exception) { }
        //}

        private static void download_Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                using (WebClient wb = new WebClient())
                {
                    File.WriteAllText("version.xml", wb.DownloadString(UpdatePath.VersionPathOnServer));
                }

                SettingController.IsFirstStart = true;
                Process.Start("updater.exe", "TradeUpHelper.update TradeUpHelper.exe");
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
            Version minVersionForUpdate = new Version(docRemoteVersion.GetElementsByTagName("min_version_for_update")[0].InnerText);

            if(minVersionForUpdate>localVersion)
            {
                return;
            }
            if (localVersion < remoteVersion)
            {
                Update();
            }
        }
    }
}
