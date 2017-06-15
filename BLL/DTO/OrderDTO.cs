using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class OrderDTO:DTO
    {
        public string OrderDate { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
    }
}
