using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        ManagerDTO GetManager(int? id);
        IEnumerable<ManagerDTO> GetManagers();
        ClientDTO GetClient(int? id);
        IEnumerable<ClientDTO> GetClients();
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}
