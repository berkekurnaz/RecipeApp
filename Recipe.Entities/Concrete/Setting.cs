using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Entities.Concrete
{
    public class Setting : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Icon { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }

        public string SeoName { get; set; }
        public string SeoDescription { get; set; }
        public string SeoHeader { get; set; }

    }
}
