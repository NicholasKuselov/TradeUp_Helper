using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private static HttpClient client = new HttpClient();
        private static string GET(string url)
        {
            var response = client.GetAsync(url);
            return response.Result.Content.ReadAsStringAsync().Result;
        }
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

        public static string SendPost(string url,Dictionary<string,string> postDataDict)
        {
            if (postDataDict.Count <= 0) return "";

            var content = new FormUrlEncodedContent(postDataDict);

            var response = client.PostAsync(url, content);

            var responseString = response.Result;
            string res = responseString.Content.ReadAsStringAsync().Result.ToString();

            string utfLine = "";

            Encoding utf = Encoding.UTF8;
            Encoding win = Encoding.GetEncoding(1251);

            byte[] utfArr = utf.GetBytes(utfLine);
            byte[] winArr = Encoding.Convert(win, utf, utfArr);

            string winLine = win.GetString(winArr);
            return res;

            //MessageBox.Show(responseString.Content.ReadAsStringAsync().Result);


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

        public static string SendGetAlternative(string url)
        {
            string ss = GET(url);
            MessageBox.Show(ss);
            return ss;
        }
        public static string SendGet(string url)
        {

            string data = "";

            WebRequest request = WebRequest.Create(url);
            request.Headers.Add("Accept-Language", "ru-UA,ru;q=0.9,en-US;q=0.8,en;q=0.7,uk-UA;q=0.6,uk;q=0.5,ru-RU;q=0.4");
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
