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
            var db = Data.ProductManager.GetProducts();
            
            foreach (var cartItem in Data.CartManager.Cart)
            {
                foreach (var product in db)
                {
                    if (cartItem.ProductId == product.Id)
                    {
                        if (cartItem.Count > product.UnitsInStock)
                        {
                            product.UnitsInStock = 0;
                        }
                        else
                        {
                            product.UnitsInStock -= cartItem.Count;
                        }
                    }
                }
            }
            Data.ProductManager.Products = db;

            Response.Cookies.Delete("Cart");

            Data.CartManager.ClearCart();
            return RedirectToPage("/ShoppingCart/OrderConfirmation");
        }
    }
}
