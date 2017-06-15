using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }

        public Client ClientSet { get; set; }
        public Manager ManagerSet { get; set; }
        public Product ProductSet { get; set; }
    }
}
