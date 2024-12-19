//using HtmlAgilityPack;
//using SozcuDataCrawler.Core.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SozcuDataCrawler.Infrastructure.Services
//{
//    public class SozcuWebCrawler : IWebCrawler
//    {
//        public async Task<string> CrawlAsync(string url)
//        {
//            try
//            {
//                using (HttpClient client = new HttpClient())
//                {
//                    // Web sayfasını indir
//                    string htmlContent = await client.GetStringAsync(url);

//                    // HTML içeriğini analiz et
//                    HtmlDocument document = new HtmlDocument();
//                    document.LoadHtml(htmlContent);

//                    // Örnek: Sayfanın başlığını çekme
//                    var titleNode = document.DocumentNode.SelectSingleNode("//title");

//                    return titleNode != null ? titleNode.InnerText : "Başlık bulunamadı.";
//                }
//            }
//            catch (Exception ex)
//            {
//                // Hata durumunda mesaj döndür
//                return $"Hata oluştu: {ex.Message}";
//            }
//        }
//    }
//}


using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SozcuDataCrawler.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozcuDataCrawler.Infrastructure.Services
{
    public class SozcuWebCrawler
    {
        private readonly HttpClient _httpClient;

        public SozcuWebCrawler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<(string Title, string Link)>> CrawlAsync(string url)
        {
            var results = new List<(string Title, string Link)>();
            try
            {
                var response = await _httpClient.GetStringAsync(url);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response);

                // Haber başlıklarını ve bağlantılarını seçin
                var articles = htmlDoc.DocumentNode.SelectNodes("/html/body/div[3]//a");

                if (articles != null)
                {
                    foreach (var article in articles)
                    {
                        var title = article.InnerText.Trim();
                        var link = article.GetAttributeValue("href", string.Empty);

                        if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(link))
                        {
                            results.Add((title, link));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Crawl sırasında bir hata oluştu: {ex.Message}");
            }

            return results;
        }
    }
}

