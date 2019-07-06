using LiteDB;
using Recipe.DataAccess.Abstract;
using Recipe.Entities.Abstract;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDBaseRepository<T> : IBaseRepository<T> where T : BaseEntity, IEntity, new()
    {

        string repoName;

        public LDBaseRepository(string repoName)
        {
            this.repoName = repoName;
        }

        /* Database Insert Operation */
        public void Add(T entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<T>(repoName);
                items.Insert(entity);
            }
        }

        /* Database Delete Operation */
        public void Delete(int Id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<T>(repoName);
                items.Delete(Id);
            }
        }

        /* Database List Operation */
        public List<T> GetAll()
        {
            var list = new List<T>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<T>(repoName);
                foreach (T item in items.FindAll())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Database Get Operation */
        public T GetById(int Id)
        {
            var item = new T();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<T>(repoName);
                item = items.Find(x => x.Id == Id).FirstOrDefault();
            }
            return item;
        }

        /* Database Update Operation */
        public void Update(T entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<T>(repoName);
                items.Update(entity);
            }
        }

    }
}
