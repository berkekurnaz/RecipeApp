using Recipe.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Entities.Concrete
{
    public class Author : IEntity
    {

        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string ApiKey { get; set; }
        public string CreatedDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Author()
        {

        }

        public Author(string NameSurname, string Description, string Photo, string ApiKey, string CreatedDate, string Username, string Password)
        {
            this.NameSurname = NameSurname;
            this.Description = Description;
            this.Photo = Photo;
            this.ApiKey = ApiKey;
            this.CreatedDate = CreatedDate;
            this.Username = Username;
            this.Password = Password;
        }

    }
}
