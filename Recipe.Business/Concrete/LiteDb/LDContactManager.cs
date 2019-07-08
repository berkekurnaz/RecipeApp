using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Concrete.LiteDb
{
    public class LDContactManager : IContactService
    {

        string repoName;
        private LDContactDal _contactDal;

        public LDContactManager(string repoName)
        {
            this.repoName = repoName;
            _contactDal = new LDContactDal(repoName);
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void Delete(int Id)
        {
            _contactDal.Delete(Id);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetById(int Id)
        {
            return _contactDal.GetById(Id);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
