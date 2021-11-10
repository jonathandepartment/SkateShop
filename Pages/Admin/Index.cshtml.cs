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
        public List<ProductModel> Products = new List<ProductModel>();

        public void OnGet()
        {
            this.Products = Data.ProductManager.GetProducts();
          

        }
    }
}
