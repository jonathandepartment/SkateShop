using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SkateShop.Models.Enum;

namespace SkateShop.Models
{
    public abstract class ProductModel
    {
        public double Price { get; set; }
        public int Id { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public bool Chosen { get; set; }
        public string Image { get; set; }
    }

    public class Clothing : ProductModel
    {
        public Size Size { get; set; }
    }

    public class Boards : ProductModel
    {
        public double BoardSize { get; set; }
        public Material Material { get; set; }
    }
    public class Wheels : ProductModel
    {
        public int WheelSize { get; set; }
        public string Durometer { get; set; }
    }
    public class Shoes : ProductModel
    {
        public int ShoeSizeEu { get; set; }
    }

}
