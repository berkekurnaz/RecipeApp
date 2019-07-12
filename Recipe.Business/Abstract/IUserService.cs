using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int Id);
        void Add(User user);
        void Update(User user);
        void Delete(int Id);
        User Login(User user);
    }
}
