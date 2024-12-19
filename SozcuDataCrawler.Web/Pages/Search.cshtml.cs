using Microsoft.AspNetCore.Mvc.RazorPages;
using SozcuDataCrawler.Infrastructure.Services;

namespace SozcuDataCrawler.Web.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ElasticsearchService _elasticsearchService;

        public List<Article> SearchResults { get; set; } = new List<Article>();
        public List<Article> UniqueArticles { get; set; } = new List<Article>();

        public SearchModel()
        {
            _elasticsearchService = new ElasticsearchService();
        }

        public async Task OnGetAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                // Tüm verileri al
                SearchResults = await _elasticsearchService.SearchDataAsync("");
            }
            else
            {
                // Sadece ilgili verileri al
                SearchResults = await _elasticsearchService.SearchDataAsync(query);
            }

            // Benzersiz verileri al
            UniqueArticles = SearchResults.DistinctBy(article => article.Content).ToList();
        }
    }


}
