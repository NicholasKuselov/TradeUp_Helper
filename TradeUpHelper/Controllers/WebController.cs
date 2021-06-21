using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TradeUpHelper.Constants;

namespace TradeUpHelper.Controllers
{
    class WebController
    {
        public static bool CheckConnection()
        {
            WebClient client = new WebClient();
            try
            {
                using (client.OpenRead("http://www.google.com"))
                {
                }
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }

        public static string GetItemProp(string itemOverlayURL)
        {

            string data = "";

            string path = WebPath.CSGOFloat + itemOverlayURL;

            WebRequest request = WebRequest.Create(path);
            WebResponse response = request.GetResponse();


            try
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        data = reader.ReadToEnd();
                        stream.Close();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error with void GetItemProp");
            }

            response.Close();


            data = data.Substring(data.IndexOf(":") + 1, data.Length - data.IndexOf(":") - 2);
            return data;
        }

        public static ImageSource GetImageByURL(string imageUrl)
        {
            if (imageUrl == "") return null;
            return new BitmapImage(new Uri(imageUrl));
        }

        public static string GetInventory()
        {

            string data = "";

            string path = SettingController.UserInventoryURL + "json/730/2";

            WebRequest request = WebRequest.Create(path);
            WebResponse response = request.GetResponse();


            try
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        data = reader.ReadToEnd();
                        stream.Close();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error with void GetItemProp");
            }

            response.Close();


            return data;
        }

        public static string SendGet(string url)
        {

            string data = "";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();


            try
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        data = reader.ReadToEnd();
                        stream.Close();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error with void GetItemProp");
            }

            response.Close();


            return data;
        }

    }
}
