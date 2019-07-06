﻿using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Concrete.LiteDb
{
    public class LDUserManager : IUserService
    {

        private LDUserDal _userDal = new LDUserDal("Users");

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(int Id)
        {
            _userDal.Delete(Id);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(int Id)
        {
            return _userDal.GetById(Id);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}