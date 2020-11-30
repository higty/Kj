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

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='newsFeed_item_title']");
            foreach (HtmlNode node in nodes)
            {
                var title = node.InnerText;
                Console.WriteLine(title);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
