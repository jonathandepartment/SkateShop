using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SkateShop.Pages
{   
    [BindProperties]
    public class AddProductModel : PageModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public bool Chosen { get; set; }
        public string Image { get; set; }
        public Models.Enum.Color Color { get; set; }
        public Models.Enum.Category Category { get; set; }
        //Clothing
        public Models.Enum.Size Size { get; set; }
        //Board
        public double BoardSize { get; set; }
        public Models.Enum.Material Material { get; set; }
        //Wheels
        public int WheelSize { get; set; }
        public string Durometer { get; set; }
        //Shoes
        public int ShoeSizeEu { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost() { 

            Models.ProductModel productToAdd = null;
            UInt32 id = Data.ProductManager._ID++ ; 

            if(Category == Models.Enum.Category.Cap
               || Category == Models.Enum.Category.Hoodie
               || Category == Models.Enum.Category.Tshirt) productToAdd = new Models.Clothing
                {
                    Id = Convert.ToInt32(id),
                    Price = Price,
                    Name = Name,
                    Category = Category,
                    Color = Color,
                    Description = Description,
                    UnitsInStock = UnitsInStock,
                    Chosen = Chosen,
                    Image = Image,
                    Size = Size
                };
            else if (Category == Models.Enum.Category.Shoes) productToAdd = new Models.Shoes
            {
                Id = Convert.ToInt32(id),
                Price = Price,
                Name = Name,
                Category = Category,
                Color = Color,
                Description = Description,
                UnitsInStock = UnitsInStock,
                Chosen = Chosen,
                Image = Image,
                ShoeSizeEu = ShoeSizeEu
            };
            else if (Category == Models.Enum.Category.Skateboard) productToAdd = new Models.Boards
            {
                Id = Convert.ToInt32(id),
                Price = Price,
                Name = Name,
                Category = Category,
                Color = Color,
                Description = Description,
                UnitsInStock = UnitsInStock,
                Chosen = Chosen,
                Image = Image,
                BoardSize = BoardSize,
                Material = Material
            };
            else if (Category == Models.Enum.Category.Wheel) productToAdd = new Models.Wheels
            {
                Id = Convert.ToInt32(id),
                Price = Price,
                Name = Name,
                Category = Category,
                Color = Color,
                Description = Description,
                UnitsInStock = UnitsInStock,
                Chosen = Chosen,
                Image = Image,
                WheelSize = WheelSize,
                Durometer = Durometer
            };
            Data.ProductManager.AddProduct(productToAdd); 

            return Redirect("/Admin/Index");
        }


    }
}
