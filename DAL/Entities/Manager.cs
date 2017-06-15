using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Manager:Entity
    {
        public string ManagerName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
