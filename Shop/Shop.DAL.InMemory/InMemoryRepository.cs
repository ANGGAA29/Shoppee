using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.InMemory
{
    public class InMemoryRepository<T> where T: BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }

        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T p)
        {
            items.Add(p);
        }

        public void Update(T p)
        {
            T itemToUpdate = items.Find(x => x.Id == p.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate = p;
            }
            else
            {
                throw new Exception(className + " not found");
            }
        }

        public T Find(string id)
        {
            T item = items.Find(x => x.Id == id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception(className + " not found");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string id)
        {
            T item = items.Find(x => x.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }
            else
            {
                throw new Exception(className + " not found");
            }
        }
    }
}
