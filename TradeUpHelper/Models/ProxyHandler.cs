using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    class ProxyHandler
    {
        public static List<WebProxy> ProxyList;

        static ProxyHandler()
        {
            ProxyList = new List<WebProxy>() {new WebProxy("159.8.114.34",8123),
                                              new WebProxy("185.216.231.135",8888),
                                              new WebProxy("188.170.233.102",3128)};
        }
    }
}
