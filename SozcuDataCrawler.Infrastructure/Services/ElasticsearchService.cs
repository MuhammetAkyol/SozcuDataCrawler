using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nest;

namespace SozcuDataCrawler.Infrastructure.Services
{
    public class ElasticsearchService
    {
        private readonly ElasticClient _client;

        public ElasticsearchService()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("sozcu-data");
            _client = new ElasticClient(settings);
        }

        // Veri ekleme
        //public async Task IndexDataAsync(string data)
        //{
        //    var response = await _client.IndexDocumentAsync(new
        //    {
        //        Content = data,
        //        Timestamp = DateTime.Now
        //    });

        //    if (!response.IsValid)
        //    {
        //        Console.WriteLine($"Elasticsearch Hatası: {response.OriginalException?.Message}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Veri Elasticsearch'e başarıyla kaydedildi.");
        //    }
        //}

        // Veri daha fazla ekleme
        public async Task IndexBulkDataAsync(List<Article> data)
        {
            var bulkAllObservable = _client.BulkAll(data, b => b
                .Index("sozcu-data")
                .BackOffRetries(2)
                .BackOffTime("30s")
                .RefreshOnCompleted()
                .MaxDegreeOfParallelism(Environment.ProcessorCount)
                .Size(1000));

            try
            {
                bulkAllObservable.Wait(TimeSpan.FromMinutes(2), response =>
                {
                    Console.WriteLine("Veri partisi Elasticsearch'e başarıyla işlendi.");
                });

                Console.WriteLine("Tüm veriler Elasticsearch'e başarıyla işlendi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bulk işleminde hata: {ex.Message}");
            }
        }




        // Veri arama
        public async Task<List<Article>> SearchDataAsync(string query)
        {
            var response = await _client.SearchAsync<Article>(s =>
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    // Boş sorgu için tüm verileri getir
                    return s.Index("sozcu-data").Query(q => q.MatchAll());
                }
                else
                {
                    // Normal arama işlemi
                    return s.Index("sozcu-data").Query(q => q
                        .Match(m => m
                            .Field(f => f.Content)
                            .Query(query)
                        )
                    );
                }
            });

            return response.Documents.ToList();
        }

    }
}
