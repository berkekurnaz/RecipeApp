using Recipe.Entities.Concrete;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.MvcWebUI.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Article> PopularArticles { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
        public IPagingList MyPagingModel { get; set; }
    }
}
