using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Client:Entity
    {
        public string ClientName { get; set; }

        public  ICollection<Order> Orders { get; set; }
    }
}
