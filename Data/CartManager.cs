using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkateShop.Models;

namespace SkateShop.Data
{
    public class CartManager
    {

        public static List<CartItemModel> Cart { get; set; } = new List<CartItemModel>();

        public static void AddToCart(ProductModel product)
        {
            if (IsItInCart(product))
            {
                foreach (var item in Cart)
                {
                    if (item.Product.Id == product.Id)
                    {
                        if (item.Count + 1 <= product.UnitsInStock)
                        {
                            item.Count++;
                        }
                    }
                }
            }
            else
            {
                var productToAdd = new CartItemModel
                {
                    Product = product,
                    Count = 1
                };
                Cart.Add(productToAdd);
            }
        }

        private static bool IsItInCart(ProductModel product)
        {
            var productsInCart = Cart.Select(item => item.Product);
            return productsInCart.Contains(product);
        }

        public static void ClearCart() => Cart.Clear();
        public static void RemoveCartItem(int id)
        {
            Cart = Cart.Where(item => item.Product.Id != id).ToList();
        }

        public static double GetCartTotal()
        {
            return Cart.Sum(item => item.Product.Price * item.Count);             
        }
    }
}
