using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace WebScrapingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = new HttpClient();
            //非同期呼び出し
            var html = cl.GetStringAsync("https://news.yahoo.co.jp/topics/entertainment").Result;

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='newsFeed_item_text']");
            foreach (HtmlNode node in nodes)
            {
                var titleNode = node.SelectSingleNode("div[@class='newsFeed_item_title']");
                var title = titleNode.InnerText;
                var timeNode = node.SelectSingleNode("div//time[@class='newsFeed_item_date']");
                var time = timeNode.InnerText;
                Console.WriteLine(time + " " + title);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
