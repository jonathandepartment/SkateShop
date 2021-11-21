using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SkateShop.Models;
using static SkateShop.Models.Enum;

namespace SkateShop.Data
{
    public class ProductManager
    {
        public static List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public static UInt32 _ID { get; set; } = 49;

        public static List<ProductModel> GetHighlightedProducts()
        {
            return GetProducts().Where(product => product.Chosen)
                .ToList();
        }

        public static void RemoveProduct(int id)
        {
            // Products = Products.Where(product => product.Id != id).ToList();
            var client = new RestClient("https://localhost:44303/product/"+id);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
           
        }


        public static List<ProductModel> GetSearchedProduct(string search)
        {
            return GetProducts().Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
        }

        public static ProductModel GetProduct(int id)
        {
            return GetProducts().Where(product => product.Id == id).ToList()[0];
        }
        public static List<ProductModel> GetProducts()
        {
            Products.Clear(); 
            var client = new RestClient("https://localhost:44303/product/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if ((int)response.StatusCode == 200)
            {
                JArray jsonArray = JArray.Parse(response.Content);

           
          

            foreach (JObject jsonProduct in jsonArray.Children())
            {
                int id = (int)jsonProduct.GetValue("id");
                double price = (double)jsonProduct.GetValue("price");
                Category category = (Category)(int)jsonProduct.GetValue("category");
                Color color = (Color)(int)jsonProduct.GetValue("color");
                string description = (string)jsonProduct.GetValue("description");
                string name = (string)jsonProduct.GetValue("name");
                int unitsInStock = (int)jsonProduct.GetValue("unitsInStock");
                bool chosen = (bool)jsonProduct.GetValue("chosen");
                string image = (string)jsonProduct.GetValue("image");

                if ((int)category == 0 || (int)category == 1 || (int)category == 3)
                {
                    Size size = (Size)(int)jsonProduct.GetValue("size");

                    Products.Add(new Clothing
                    {
                        Id = id,
                        Price = price,
                        Name = name,
                        Category = category,
                        Color = color,
                        Description = description,
                        UnitsInStock = unitsInStock,
                        Chosen = chosen,
                        Image = image,
                        Size = size
                    });
                }
                else if ((int)category == 2)
                {
                    double boardSize = (double)jsonProduct.GetValue("boardSize");
                    Material material = (Material)(int)jsonProduct.GetValue("material");
                    Products.Add(new Boards
                    {
                        Id = id,
                        Price = price,
                        Name = name,
                        Category = category,
                        Color = color,
                        Description = description,
                        UnitsInStock = unitsInStock,
                        Chosen = chosen,
                        Image = image,
                        BoardSize = boardSize,
                        Material = material
                    });
                }
                else if ((int)category == 4)
                {
                    int wheelSize = (int)jsonProduct.GetValue("wheelSize"); ;
                    string durometer = (string)jsonProduct.GetValue("durometer"); ;
                    Products.Add(new Wheels
                    {
                        Id = id,
                        Price = price,
                        Name = name,
                        Category = category,
                        Color = color,
                        Description = description,
                        UnitsInStock = unitsInStock,
                        Chosen = chosen,
                        Image = image,
                        WheelSize = wheelSize,
                        Durometer = durometer
                    });
                }
                else if ((int)category == 5)
                {
                    int shoeSizeEu = (int)jsonProduct.GetValue("shoeSizeEu");
                    Products.Add(new Shoes
                    {
                        Id = id,
                        Price = price,
                        Name = name,
                        Category = category,
                        Color = color,
                        Description = description,
                        UnitsInStock = unitsInStock,
                        Chosen = chosen,
                        Image = image,
                        ShoeSizeEu = shoeSizeEu
                    });
                }
                }
              
            }
            return Products; 
        }

        public static bool AddProduct(ProductModel productToAdd)
        {
            if (Products.Contains(productToAdd)) return false;

            var client = new RestClient("https://localhost:44303/product/");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            JObject jsonBody = null;

            int clothingSize = 0, wheelSize  = 0 , shoeSize = 0, material = 0;
            double boardSize = 0; 
            string wheelDurometer = "";

            if (productToAdd is Clothing) clothingSize = (int)((Clothing)productToAdd).Size;
            else if (productToAdd is Boards)
            {
                boardSize = ((Boards)productToAdd).BoardSize;
                material = (int)((Boards)productToAdd).Material;
            }
            else if (productToAdd is Wheels)
            {
                wheelSize = ((Wheels)productToAdd).WheelSize;
                wheelDurometer = ((Wheels)productToAdd).Durometer;
            }
            else if (productToAdd is Shoes) shoeSize = ((Shoes)productToAdd).ShoeSizeEu;


            jsonBody = JObject.Parse(JsonConvert.SerializeObject(
                    new
                    {
                        price = productToAdd.Price,
                        id = productToAdd.Id,
                        category = (int)productToAdd.Category,
                        color = (int)productToAdd.Color,
                        description = productToAdd.Description,
                        name = productToAdd.Name,
                        unitsInStock = productToAdd.UnitsInStock,
                        chosen = productToAdd.Chosen,
                        image = productToAdd.Image,
                        size = clothingSize, 
                        boardSize = boardSize,
                        material = material,
                        wheelSize = wheelSize,
                        durometer = wheelDurometer,
                        shoeSizeEu = shoeSize
                    }));

            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            if ((int)response.StatusCode == 200) return true;
            else return false; 
        }

        public static void EditProduct(ProductModel editedProduct, int id)
        {
            int index = Products.IndexOf(GetProducts().Where(product => product.Id == id).ToList()[0]);
            if(index != -1)
            {
                var client = new RestClient("https://localhost:44303/product/" + id);
                client.Timeout = -1;

                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                JObject jsonBody = null;

                int clothingSize = 0, wheelSize = 0, shoeSize = 0, material = 0;
                double boardSize = 0;
                string wheelDurometer = "";

                if (editedProduct is Clothing) clothingSize = (int)((Clothing)editedProduct).Size;
                else if (editedProduct is Boards)
                {
                    boardSize = ((Boards)editedProduct).BoardSize;
                    material = (int)((Boards)editedProduct).Material;
                }
                else if (editedProduct is Wheels)
                {
                    wheelSize = ((Wheels)editedProduct).WheelSize;
                    wheelDurometer = ((Wheels)editedProduct).Durometer;
                }
                else if (editedProduct is Shoes) shoeSize = ((Shoes)editedProduct).ShoeSizeEu;

                jsonBody = JObject.Parse(JsonConvert.SerializeObject(
                    new
                    {
                        price = editedProduct.Price,
                        id = editedProduct.Id,
                        category = (int)editedProduct.Category,
                        color = (int)editedProduct.Color,
                        description = editedProduct.Description,
                        name = editedProduct.Name,
                        unitsInStock = editedProduct.UnitsInStock,
                        chosen = editedProduct.Chosen,
                        image = editedProduct.Image,
                        size = clothingSize,
                        boardSize = boardSize,
                        material = material,
                        wheelSize = wheelSize,
                        durometer = wheelDurometer,
                        shoeSizeEu = shoeSize,

                    }));

                request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                //Products[index] = editedProduct;
            }
            
        }
    }
}
