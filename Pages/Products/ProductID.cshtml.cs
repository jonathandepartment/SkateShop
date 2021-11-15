using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkateShop.Models;
using SkateShop.Data;

namespace SkateShop.Pages.Products
{

    public class ProductIDModel : PageModel
    {
        public int ProductID { get; set; }
        public List<ProductModel> ProductList { get; set; }
        public List<ProductModel> Product { get; set; }

        public void OnGet(int id)
        {
            ProductID = id;
            ProductList = ProductManager.GetProducts();
            Product = ProductList.Where(p => p.Id == ProductID).ToList();
        }
    }
}
