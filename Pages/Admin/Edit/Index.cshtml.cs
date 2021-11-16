using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SkateShop.Pages.Admin.Edit
{
    public class IndexModel : PageModel
    {

        public Models.ProductModel Product { get; set; }
        public int ProductId { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public int UnitsInStock { get; set; }
        [BindProperty]
        public bool Chosen { get; set; }
        [BindProperty]
        public string Image { get; set; }
        [BindProperty]
        public Models.Enum.Color Color { get; set; }

        public Models.Enum.Category Category { get; set; }

        //Clothing
        [BindProperty]
        public Models.Enum.Size Size { get; set; }
        //Board
        [BindProperty]
        public double BoardSize { get; set; }
        [BindProperty]
        public Models.Enum.Material Material { get; set; }
        //Wheels
        [BindProperty]
        public int WheelSize { get;set;}
        [BindProperty]
        public string Durometer { get; set; }
        //Shoes
        [BindProperty]
        public int ShoeSizeEu { get; set; }


        public void OnGet(int id)
        {

            this.Product = Data.ProductManager.GetProduct(id);
            this.ProductId = id; 
            this.Name = Product.Name;
            this.Price = Product.Price;
            this.Description = Product.Description;
            this.UnitsInStock = Product.UnitsInStock;
            this.Chosen = Product.Chosen;
            this.Image = Product.Image;
            this.Color = Product.Color;
            this.Category = Product.Category;

            if (this.Product is Models.Clothing) this.Size = ((Models.Clothing)Product).Size;
            else if (this.Product is Models.Shoes) this.ShoeSizeEu = ((Models.Shoes)Product).ShoeSizeEu;
            else if (this.Product is Models.Boards)
            {   this.BoardSize = ((Models.Boards)Product).BoardSize; 
                this.Material = ((Models.Boards)Product).Material;
            }else if (this.Product is Models.Wheels)
            {   this.WheelSize = ((Models.Wheels)Product).WheelSize;
                this.Durometer = ((Models.Wheels)Product).Durometer;
            }
        }

        public IActionResult OnGetDelete(int id)
        {
            Data.ProductManager.RemoveProduct(id);
            return RedirectToPage("/Admin/Index");
        }
        
        public IActionResult OnPostSubmit(int id, Models.Enum.Category category)
        {
            Models.ProductModel editedProduct = null;
            Console.WriteLine(category);

            if (category == Models.Enum.Category.Hoodie
                || category == Models.Enum.Category.Cap
                || category == Models.Enum.Category.Hoodie
                || category == Models.Enum.Category.Tshirt) editedProduct = new Models.Clothing
                {
                    Id = id,
                    Price = Price,
                    Name = Name,
                    Category = category,
                    Color = Color,
                    Description = Description,
                    UnitsInStock = UnitsInStock,
                    Chosen = Chosen,
                    Image = Image,
                    Size = Size
                };
            else if (category == Models.Enum.Category.Shoes ) editedProduct = new Models.Shoes
            {
                Id = id,
                Price = Price,
                Name = Name,
                Category = category,
                Color = Color,
                Description = Description,
                UnitsInStock = UnitsInStock,
                Chosen = Chosen,
                Image = Image,
                ShoeSizeEu = ShoeSizeEu
            };
            else if (category == Models.Enum.Category.Skateboard) editedProduct = new Models.Boards
                {
                    Id = id,
                    Price = Price,
                    Name = Name,
                    Category = category,
                    Color = Color,
                    Description = Description,
                    UnitsInStock = UnitsInStock,
                    Chosen = Chosen,
                    Image = Image,
                    BoardSize = BoardSize,
                    Material = Material
                };
            else if (category == Models.Enum.Category.Wheel) editedProduct = new Models.Wheels
            {
                Id = id,
                Price = Price,
                Name = Name,
                Category = category,
                Color = Color,
                Description = Description,
                UnitsInStock = UnitsInStock,
                Chosen = Chosen,
                Image = Image,
                WheelSize = WheelSize,
                Durometer = Durometer
            };

            Data.ProductManager.EditProduct(editedProduct, id);
            return RedirectToPage("/Admin/Index");
        }
    }
}
