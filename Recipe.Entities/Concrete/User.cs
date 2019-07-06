using Recipe.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Entities.Concrete
{
    public class User: IEntity
    {

        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string CreatedDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public User()
        {

        }

        public User(string NameSurname, string Mail, string CreatedDate, string Username, string Password, string Photo)
        {
            this.NameSurname = NameSurname;
            this.Mail = Mail;
            this.CreatedDate = CreatedDate;
            this.Username = Username;
            this.Password = Password;
            this.Photo = Photo;
        }

    }
}
