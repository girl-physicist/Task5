using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class GeneralRepository<T> : IRepository<T> where T : Entity
    {
        private readonly SaleContext _db;

        public GeneralRepository(SaleContext context)
        {
            _db = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Create(T item)
        {
            _db.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            T item = _db.Set<T>().Find(id);
            if (item != null)
                _db.Set<T>().Remove(item);
        }
    }
}
