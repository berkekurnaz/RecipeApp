using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int Id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int Id);
    }
}
