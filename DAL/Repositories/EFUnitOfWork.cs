using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
   public class EFUnitOfWork:IUnitOfWork
    {
        private readonly SaleContext _db;

        public EFUnitOfWork(SaleContext context)
        {
            _db = context;
        }
      
        private GeneralRepository<Manager> _managerRepository;
        private GeneralRepository<Client> _clientRepository;
        private GeneralRepository<Product> _productRepository;
        private GeneralRepository<Order> _orderRepository;

       
        

        public IRepository<Product> Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new GeneralRepository<Product>(_db);
                return _productRepository;
            }
        }

        public IRepository<Manager> Managers
        {
            get
            {
                    if (_managerRepository == null)
                        _managerRepository = new GeneralRepository<Manager>(_db);
                    return _managerRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new GeneralRepository<Client>(_db);
                return _clientRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new GeneralRepository<Order>(_db);
                return _orderRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
