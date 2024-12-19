using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozcuDataCrawler.Infrastructure.Services
{
    public class Article
    {
        public string Content { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
