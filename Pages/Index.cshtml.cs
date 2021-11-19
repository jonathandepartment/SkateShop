using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkateShop.Models;
using SkateShop.Data;
using System.Text.Json;

namespace SkateShop.Pages
{
    public class IndexModel : PageModel
    {
        public List<ProductModel> ProductList { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["Cart"]))
            {
                var jsonToList = JsonSerializer.Deserialize<List<CartItemModel>>(Request.Cookies["Cart"]);
                CartManager.Cart = jsonToList;
            }

            ProductList = new List<ProductModel>();

            ProductList = ProductManager.GetProducts();

            ProductList = ProductList.Where(p => p.Chosen).ToList();
        }
    }
}
