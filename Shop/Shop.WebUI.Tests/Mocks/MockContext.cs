using Shop.Core.Contracts;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WebUI.Tests.Mocks
{
    public class MockContext<T> : IRepository<T> where T : BaseEntity
    {
        List<T> items;
        string className;

        public MockContext()
        {
            items = new List<T>();

        }

        public void Commit()
        {
            return;
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
