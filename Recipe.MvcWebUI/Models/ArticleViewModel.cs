using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.MvcWebUI.Models
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Article> MostPopular { get; set; }
        public List<Category> Categories { get; set; }
    }
}
