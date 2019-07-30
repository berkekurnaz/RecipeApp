using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.MvcWebUI.Models
{
    public class ContactViewModel
    {
        public Setting Setting { get; set; }
        public Contact Contact { get; set; }
    }
}
