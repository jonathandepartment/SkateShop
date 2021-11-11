using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkateShop.Models;

namespace SkateShop.Data
{
    public class CartManager
    {
        public static List<CartItemModel> Cart { get; set; } = new List<CartItemModel>
                {
                    new CartItemModel
                {
                    Product = new Models.Shoes
                    {
                        Id = 1,
                        Price = 699,
                        Name = "DC",
                        Category = Models.Enum.Category.Shoes,
                        Color = Models.Enum.Color.Grey,
                        Chosen = false,
                        Description = "Excellent shoes for skating. Durable, lightweight and closefitting for agility",
                        Image = "~/Assets/products/sinus-cap-blue.png",
                        UnitsInStock = 10,
                        ShoeSizeEu = 43
                    },
                    Count = 1
                },
                    new CartItemModel
                {
                    Product = new Models.Shoes
                    {
                        Id = 3,
                        Price = 499,
                        Name = "DC",
                        Category = Models.Enum.Category.Shoes,
                        Color = Models.Enum.Color.Grey,
                        Chosen = false,
                        Description = "Excellent shoes for skating. Durable, lightweight and closefitting for agility",
                        Image = "https://images.blue-tomato.com/is/image/bluetomato/304263560_front.jpg-4YT7onA_uQovNtQuNrZCa8dXK1Q/Tonik+Skateskor.jpg?$b8$",
                        UnitsInStock = 10,
                        ShoeSizeEu = 43
                    },
                    Count = 1
                }
                };

        public static void AddToCart(ProductModel product)
        {
            var productToAdd = new CartItemModel
            {
                Product = product,
                Count = 1
            };
            Cart.Add(productToAdd);
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
