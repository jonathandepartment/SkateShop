using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkateShop.Models;
using SkateShop.Data;

namespace SkateShop.Pages
{
    public class IndexModel : PageModel
    {
        public List<ProductModel> ProductList { get; set; }

        public void OnGet()
        {
            ProductList = new List<ProductModel>();

            ProductList = Data.ProductManager.GetProducts();

            ProductList = ProductList.Where(p => p.Chosen).ToList();
        }
    }
}
