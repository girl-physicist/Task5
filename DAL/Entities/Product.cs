using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Product :Entity
    {
        public string ProductName { get; set; }
        public string ProductCost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
