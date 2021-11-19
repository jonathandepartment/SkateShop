using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkateShop.Models;

namespace SkateShop.Pages.Products
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public List<ProductModel> ProductList { get; set; }
        public List<ProductModel> HoodieList { get; set; }
        public List<ProductModel> SkateBoardList { get; set; }
        public List<ProductModel> TshirtList { get; set; }
        public List<ProductModel> WheelList { get; set; }
        public List<ProductModel> ShoeList { get; set; }
        public List<ProductModel> SearchList { get; set; }
        public void OnGet()
        {
            ProductList = Data.ProductManager.GetProducts();

            HoodieList = ProductList.Where(p => p.Category == Models.Enum.Category.Hoodie).ToList();
            SkateBoardList = ProductList.Where(p => p.Category == Models.Enum.Category.Skateboard).ToList();
            WheelList = ProductList.Where(p => p.Category == Models.Enum.Category.Wheel).ToList();
            ShoeList = ProductList.Where(p => p.Category == Models.Enum.Category.Shoes).ToList();


        }
            

    }
}
