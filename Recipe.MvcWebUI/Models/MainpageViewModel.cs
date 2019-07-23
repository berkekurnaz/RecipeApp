using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.MvcWebUI.Models
{
    public class MainpageViewModel
    {
        public IEnumerable<Article> RecentlyArticles2 { get; set; }
        public IEnumerable<Article> RecentlyArticles5 { get; set; }
        public IEnumerable<Article> PopularArticles { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
