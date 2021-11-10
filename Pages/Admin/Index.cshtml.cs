using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkateShop.Models;

namespace SkateShop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public List<ProductModel> ProductList { get; set; }

        public void OnGet()
        {
            ProductList = Data.ProductManager.GetProducts();

        }
    }
}
