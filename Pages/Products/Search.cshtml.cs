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
    public class SearchModel : PageModel
    {
        public List<ProductModel> SearchList { get; set; }
        public List<ProductModel> ProductList { get; set; }
        [BindProperty]
        public string Search { get; set; }
        public void OnGet(string searchString)
        {
            Search = searchString;
            ProductList = ProductManager.GetProducts();
            if (String.IsNullOrEmpty(searchString))
                SearchList = ProductList;
            else SearchList = ProductList.Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();
     
        }
    }
}
