using Recipe.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Entities.Concrete
{
    public class Contact : BaseEntity
    {

        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedDate { get; set; }

        public Contact()
        {

        }

        public Contact(string NameSurname, string Mail, string Title, string Content, string CreatedDate)
        {
            this.NameSurname = NameSurname;
            this.Mail = Mail;
            this.Title = Title;
            this.Content = Content;
            this.CreatedDate = CreatedDate;
        }

    }
}
