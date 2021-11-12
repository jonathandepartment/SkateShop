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
        public void OnGet(string SearchResult)
        {
            Search = SearchResult;
            ProductList = ProductManager.GetProducts();
            SearchList = ProductList.Where(p => p.Name.Contains(Search)).ToList();
        }

        public void OnPost(string SearchResult)
        {
            Search = SearchResult;
            ProductList = ProductManager.GetProducts();
            SearchList = ProductList.Where(p => p.Name.Contains(Search)).ToList();
        }
    }
}
