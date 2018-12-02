using System.Linq;
using Shop.Core.Models;

namespace Shop.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string id);
        T Find(string id);
        void Insert(T p);
        void Update(T p);
    }
}