using Recipe.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Entities.Concrete
{
    public class Comment : BaseEntity
    {

        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public Article Article { get; set; }
        public User User { get; set; }

        public Comment()
        {

        }

    }
}
