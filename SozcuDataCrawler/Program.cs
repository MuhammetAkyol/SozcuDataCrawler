//using SozcuDataCrawler.Infrastructure.Services;

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        var crawler = new SozcuWebCrawler();
//        var elasticsearchService = new ElasticsearchService();

//        string url = "https://www.sozcu.com.tr/";
//        string result = await crawler.CrawlAsync(url);

//        Console.WriteLine("Crawl Sonucu:");
//        Console.WriteLine(result);

//        // Veriyi Elasticsearch'e kaydet
//        await elasticsearchService.IndexDataAsync(result);
//    }
//}



using Nest;
using SozcuDataCrawler.Infrastructure.Services;
using System.Net;
using System.Text;

class Program
{

    //static async Task Main(string[] args)
    //{
    //    Console.OutputEncoding = Encoding.UTF8;
    //    var crawler = new SozcuWebCrawler();
    //    var elasticsearchService = new ElasticsearchService();

    //    string url = "https://www.sozcu.com.tr/";

    //    // Web'den veri çek
    //    var results = await crawler.CrawlAsync(url);

    //    // Veri dönüştürme
    //    var articles = results.Select(result => new Article
    //    {
    //        Content = WebUtility.HtmlDecode(result.Title),  // HTML çözümleme
    //        Link = result.Link,
    //    }).ToList();


    //    // Konsola yazdır
    //    Console.WriteLine("Haber Başlıkları ve Linkler:");
    //    foreach (var article in articles)
    //    {
    //        Console.WriteLine($"Başlık: {article.Content}");
    //        Console.WriteLine($"Link: {article.Link}");
    //        Console.WriteLine("-----------");
    //    }

    //    // Elasticsearch'e kaydet
    //    await elasticsearchService.IndexBulkDataAsync(articles);

    //    Console.WriteLine("Veriler Elasticsearch'e kaydedildi.");
    //}


    static async Task Main(string[] args)
    {
        var crawler = new SozcuWebCrawler();
        var elasticsearchService = new ElasticsearchService();

        string url = "https://www.sozcu.com.tr/";
        var results = await crawler.CrawlAsync(url);

        // Verileri çözümleyerek, yalnızca benzersiz olanları alın
        var articles = results.Select(result => new Article
        {
            Content = WebUtility.HtmlDecode(result.Title),  // HTML karakter çözümleme
            Link = result.Link,
        }).ToList();

        // DistinctBy ile aynı başlıklara sahip verileri filtrele
        var uniqueArticles = articles.DistinctBy(article => article.Content).ToList();

        Console.WriteLine("Benzersiz Haber Başlıkları ve Linkler:");
        foreach (var article in uniqueArticles)
        {
            Console.WriteLine($"Başlık: {article.Content}");
            Console.WriteLine($"Link: {article.Link}");
            Console.WriteLine("----------");
        }

        // Elasticsearch'e kaydet
        await elasticsearchService.IndexBulkDataAsync(uniqueArticles);

        Console.WriteLine("Veriler Elasticsearch'e kaydedildi.");
    }


}

