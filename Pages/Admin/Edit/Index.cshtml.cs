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

        public void OnGet(int id)
        {
            Product = Data.ProductManager.GetProduct(id);
        }

        public IActionResult OnGetDelete(int id)
        {
            Data.ProductManager.RemoveProduct(id);

            return RedirectToPage("/Admin/Index");
        }
    }
}
