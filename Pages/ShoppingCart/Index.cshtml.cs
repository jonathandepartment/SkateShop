using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkateShop.Models;

namespace SkateShop.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        public List<CartItemModel> Cart { get; set; }
        public double Total { get; set; }
        public void OnGet()
        {
            //Cart = Data.CartManager.GetCart();
            Cart = Data.CartManager.Cart;

            Total = Data.CartManager.GetCartTotal();
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            Cart = Data.CartManager.Cart;
            for (int i = 0; i < Cart.Count; i++)
            {
                Cart[i].Count = quantities[i];
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDelete(int id)
        {
            Data.CartManager.RemoveCartItem(id);
            
            return RedirectToPage("Index");
        }

        public IActionResult OnGetClear()
        {
            Data.CartManager.ClearCart();
            return RedirectToPage("Index");
        }
    }
}
