using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkateShop.Models;

namespace SkateShop.Data
{
    public class ProductManager
    {
        public static List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public static List<ProductModel> GetHighlightedProducts() 
        {
            return null;
        }
        public static List<ProductModel> GetSearchedProduct(string search)
        {
            var result = new List<ProductModel>();
            result = GetProducts().Where(p => p.Name.Contains(search)).ToList();
            return result;
        }
        public static List<ProductModel> GetProducts()
        {
            if (!Products.Any())
            {
                Products = new List<ProductModel>()
                {
                    new Clothing
                    {
                        Id = 1,
                        Price = 700,
                        Name = "Thrasher Hooded",
                        Category = Models.Enum.Category.Hoodie,
                        Color = Models.Enum.Color.Grey,
                        Description = "Durable, soft and dependable for the gnarliest skaters",
                        UnitsInStock = 10,
                        Chosen = true,
                        Image = "~/wwwroot/Assets/products/sinus-hoodie-ash.png",
                        Size = Models.Enum.Size.L
                    },
                    new Clothing
                    {
                        Id = 2,
                        Price = 700,
                        Name = "Thrasher Hooded",
                        Category = Models.Enum.Category.Hoodie,
                        Color = Models.Enum.Color.Blue,
                        Description = "Durable, soft and dependable for the gnarliest skaters",
                        UnitsInStock = 10,
                        Chosen = false,
                        Image = "~/wwwroot/Assets/products/sinus-hoodie-ocean.png",
                        Size = Models.Enum.Size.L
                    },
                    new Clothing
                    {
                        Id = 3,
                        Price = 700,
                        Name = "Thrasher Hooded",
                        Category = Models.Enum.Category.Hoodie,
                        Color = Models.Enum.Color.Red,
                        Description = "Durable, soft and dependable for the gnarliest skaters",
                        UnitsInStock = 10,
                        Chosen = false,
                        Image = "~/wwwroot/Assets/products/sinus-hoodie-fire.png",
                        Size = Models.Enum.Size.M
                    },
                    new Clothing
                    {
                        Id = 4,
                        Price = 700,
                        Name = "Thrasher Hooded",
                        Category = Models.Enum.Category.Hoodie,
                        Color = Models.Enum.Color.Blue,
                        Description = "Durable, soft and dependable for the gnarliest skaters",
                        UnitsInStock = 10,
                        Chosen = false,
                        Image = "~/wwwroot/Assets/products/sinus-hoodie-green.png",
                        Size = Models.Enum.Size.M
                    },
                    new Clothing
                    {
                        Id = 5,
                        Price = 700,
                        Name = "Thrasher Hooded",
                        Category = Models.Enum.Category.Hoodie,
                        Color = Models.Enum.Color.Blue,
                        Description = "Durable, soft and dependable for the gnarliest skaters",
                        UnitsInStock = 10,
                        Chosen = false,
                        Image = "~/wwwroot/Assets/products/sinus-hoodie-purple.png",
                        Size = Models.Enum.Size.S
                    },
                    new Boards
                    {
                        Id = 6,
                        Price = 800,
                        Name = "Gretas Fury",
                        Category = Models.Enum.Category.Skateboard,
                        Color = Models.Enum.Color.Patterned,
                        Material = Models.Enum.Material.Wood,
                        Description = "Inflamed with energetic youth",
                        UnitsInStock = 4,
                        Chosen = true,
                        BoardSize = 7.5,
                        Image = "",
                    },
                    new Boards
                    {
                        Id = 7,
                        Price = 2000,
                        Name = "Story Ink",
                        Category = Models.Enum.Category.Skateboard,
                        Color = Models.Enum.Color.Patterned,
                        Material = Models.Enum.Material.Plastic,
                        Description = "Engineered to perfection",
                        UnitsInStock = 2,
                        Chosen = false,
                        BoardSize = 7.5,
                        Image = "",
                    },
                    new Boards
                    {
                        Id = 8,
                        Price = 1899,
                        Name = "Northern lights",
                        Category = Models.Enum.Category.Skateboard,
                        Color = Models.Enum.Color.Patterned,
                        Material = Models.Enum.Material.Wood,
                        Description = "Aurora, You-rora! Handcrafted in Hemavan.",
                        UnitsInStock = 3,
                        Chosen = true,
                        BoardSize = 8,
                        Image = "",
                    },
                    new Boards
                    {
                        Id = 9,
                        Price = 2899,
                        Name = "Gold Standard",
                        Category = Models.Enum.Category.Skateboard,
                        Color = Models.Enum.Color.Patterned,
                        Material = Models.Enum.Material.Wood,
                        Description = "Luxourious gold-laminated wood, for the extravagant skater",
                        UnitsInStock = 3,
                        Chosen = false,
                        BoardSize = 8,
                        Image = "",
                    },
                    new Boards
                    {
                        Id = 10,
                        Price = 899,
                        Name = "Blazing Saddle",
                        Category = Models.Enum.Category.Skateboard,
                        Color = Models.Enum.Color.Patterned,
                        Material = Models.Enum.Material.Wood,
                        Description = "For people of the land",
                        UnitsInStock = 7,
                        Chosen = true,
                        BoardSize = 8,
                        Image = "",
                    },
                    new Wheels
                    {
                        Id = 11,
                        Price =550,
                        Name = "Spitfire Rims",
                        Color = Models.Enum.Color.Patterned,
                        Category = Models.Enum.Category.Wheel,
                        Description = "Custom made for total road contact",
                        UnitsInStock = 20,
                        Chosen = true,
                        Image = "",
                        Durometer = "99A",
                        WheelSize = 52
                    },
                    new Wheels
                    {
                        Id = 12,
                        Price = 450,
                        Name = "Bones",
                        Color = Models.Enum.Color.Patterned,
                        Category = Models.Enum.Category.Wheel,
                        Description = "Rad rides crave these rims",
                        UnitsInStock = 10,
                        Chosen = true,
                        Image = "",
                        Durometer = "99A",
                        WheelSize = 52
                    },
                    new Wheels
                    {
                        Id = 13,
                        Price = 500,
                        Name = "Spitfire Rims",
                        Color = Models.Enum.Color.Patterned,
                        Category = Models.Enum.Category.Wheel,
                        Description = "Custom made for total road contact",
                        UnitsInStock = 20,
                        Chosen = true,
                        Image = "",
                        Durometer = "99A",
                        WheelSize = 53
                    },
                    new Wheels
                    {
                        Id = 14,
                        Price = 500,
                        Name = "Spitfire Rims",
                        Color = Models.Enum.Color.Patterned,
                        Category = Models.Enum.Category.Wheel,
                        Description = "Custom made for total road contact",
                        UnitsInStock = 20,
                        Chosen = true,
                        Image = "",
                        Durometer = "99A",
                        WheelSize = 53
                    },
                };
            }

            return Products;
        }
    }
}
