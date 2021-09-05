using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using TradeUpHelper.Constants;

namespace TradeUpHelper.Controllers
{
    class NewsHandler
    {
        public List<string> News { get; set; }

        public NewsHandler()
        {
            News = ParseNews(WebController.SendGet(WebPath.Cyber_sports_ru));
        }

        private List<string> ParseNews(string html)
        {
            List<string> hrefTags = new List<string>();

            var parser = new HtmlParser();

            var document = parser.ParseDocument(html);
            foreach (IElement element in document.QuerySelectorAll("strong"))
            {
                hrefTags.Add(element.TextContent);
            }

            return hrefTags.Take(5).ToList();
        }
    }
}
