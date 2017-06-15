using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using AutoMapper;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Manager manager = Database.Managers.Get(orderDto.ManagerId);
            Client client = Database.Clients.Get(orderDto.ClientId);
            Product product = Database.Products.Get(orderDto.ProductId);
            // валидация???

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                ManagerId = manager.Id,
                ClientId = client.Id,
                ProductId = product.Id
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public ManagerDTO GetManager(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set id manager", "");
            var manager = Database.Managers.Get(id.Value);
            if (manager == null)
                throw new ValidationException("Manager  not found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, ManagerDTO>());
            return Mapper.Map<Manager, ManagerDTO>(manager);
        }

        public IEnumerable<ManagerDTO> GetManagers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, ManagerDTO>());
            return Mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(Database.Managers.GetAll());
        }

        public ClientDTO GetClient(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set id client", "");
            var client = Database.Clients.Get(id.Value);
            if (client == null)
                throw new ValidationException("Client  not found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientDTO>());
            return Mapper.Map<Client, ClientDTO>(client);
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientDTO>());
            return Mapper.Map<IEnumerable<Client>, List<ClientDTO>>(Database.Clients.GetAll());
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set id product", "");
            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Product  not found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
