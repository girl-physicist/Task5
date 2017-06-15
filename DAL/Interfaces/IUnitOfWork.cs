using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get;}
        IRepository<Order> Orders { get;}
        IRepository<Manager> Managers { get; }
        IRepository<Client> Clients { get;  }
        void Save();
    }
}
