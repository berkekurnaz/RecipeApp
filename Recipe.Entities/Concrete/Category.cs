using Recipe.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Entities.Concrete
{
    public class Category : BaseEntity
    {

        public string CategoryName { get; set; }

        public Category()
        {

        }

        public Category(string CategoryName)
        {
            this.CategoryName = CategoryName;
        }

    }
}
