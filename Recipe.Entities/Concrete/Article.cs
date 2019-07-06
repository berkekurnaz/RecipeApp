using Recipe.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Entities.Concrete
{
    public class Article : BaseEntity
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public string CreatedDate { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }

        public Article()
        {

        }

    }
}
