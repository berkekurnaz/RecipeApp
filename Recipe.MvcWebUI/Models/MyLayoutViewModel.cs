using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.MvcWebUI.Models
{
    public class MyLayoutViewModel
    {
        public Setting Setting { get; set; }
        public List<Category> Categories { get; set; }
    }
}
