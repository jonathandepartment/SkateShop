using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class OrderModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public double FreightCost { get; set; }
    }
}
