using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SkateShop.Pages.ShoppingCart
{
    public class PaymentModel : PageModel
    {
        public double Total { get; set; }
        public double Tax { get; set; }
        public List<Models.CartItemModel> CartItems { get; set; }
        public Models.OrderModel OrderInfo { get; set; }
        public void OnGet(Models.OrderModel order)
        {
            CartItems = Data.CartManager.Cart;
            Total = Data.CartManager.GetCartTotal();
            Tax = Math.Round(Total / 12, 2); // 12% Tax
            OrderInfo = order;
        }

        public IActionResult OnPost()
        {
            //Data.CartManager.RemoveFromStock(CartItems);
            Data.CartManager.ClearCart();
            return RedirectToPage("/ShoppingCart/OrderConfirmation", OrderInfo);
        }
    }
}
