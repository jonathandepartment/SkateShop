using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class ProductApiModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int unitsInStock { get; set; }
        public bool chosen { get; set; }
        public string image { get; set; }
        public string size { get; set; }
        public string additionalInformation { get; set; }
    }

}
