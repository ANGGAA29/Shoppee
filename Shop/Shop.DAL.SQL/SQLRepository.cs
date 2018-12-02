using Shop.Core.Contracts;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var t = Find(id);
            if(context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }

            dbSet.Remove(t);
        }

        public T Find(string id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T p)
        {
            dbSet.Add(p);
        }

        public void Update(T p)
        {
            dbSet.Attach(p);
            context.Entry(p).State = EntityState.Modified;
        }
    }
}
