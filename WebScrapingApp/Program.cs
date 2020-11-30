using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace WebScrapingApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        private static void Scrape_Html()
        {
            var html = @"<html>
  <body>
    <h1>ワンピース</h1>
    <div class=""item"">
      <span class=""brand"">iQON</span>
      <span class=""regular_price"">1,200円</span>
      <span class=""sale_price"">1,000円</span>
    </div>
    <span class=""title-1"">10月</span>
    <span class=""title-2"">11月</span>
    <span class=""title-3"">12月</span>
  </body>
</html>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes("//div/span[contains(@class, 'title')]");
            foreach (HtmlNode node in nodes)
            {
                Console.WriteLine(node.InnerText);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
        private static void Scrape_YahooNews()
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
