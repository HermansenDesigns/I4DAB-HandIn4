using System;
using System.Collections.Generic;
using System.Linq;
using I4DABH4.Repos;
using Microsoft.EntityFrameworkCore;

namespace I4DABH4.Data.Prosumerinfo
{
    public class Repository<T> :
        IRepository<T> where T : class
    {
        private readonly DbContext context;
        private DbSet<T> entities;
        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(long id)
        {
            return entities.Find(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var t = context.Set<T>().SingleOrDefault(o => o == entity);
            if (t != null)
                context.Entry(t).CurrentValues.SetValues(t);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
