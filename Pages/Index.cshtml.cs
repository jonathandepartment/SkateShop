using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkateShop.Models;

namespace SkateShop.Pages
{
    public class IndexModel : PageModel
    {
        public List<ProductModel> ProductList { get; set; }

        public void OnGet()
        {
            ProductList = new List<ProductModel>();
            ProductList.Add(new Clothing
            {
                Price = 700,
                Id = 1,
                Category = Models.Enum.Category.Hoodie,
                Color = Models.Enum.Color.Blue,
                Description = "A blue Sinus Hoodie",
                Name = "Sinus Hoodie Blue",
                UnitsInStock = 10,
                Chosen = true,
                Image = "https://db3pap001files.storage.live.com/y4paccGmL3Dzt_WS1Hj8WvXTYOA9Mb6UdGXRCNYHWbFx0EOYzzmaGaxBTjXRnOi8OJI9r_XSAbesgwVffilDXHZSCRGdLzq_qItnGzEwUFbVTYLWFMq2sf9-_kgQFpBToQtEASk4bdZ36MvuF4QFHEA_lNzv3cmjnTjblt_YapcVE7xSX1NqP4ZUD-SnTYis3lBPYV8N2lm7CKgBIERCMLLr2lfZquzY6SSUT0G22gK1BU/sinus-hoodie-ocean.png?psid=1&width=572&height=620"
            });

            ProductList.Add(new Clothing
            {
                Price = 300,
                Id = 2,
                Category = Models.Enum.Category.Hoodie,
                Color = Models.Enum.Color.Red,
                Description = "A red sinus cap",
                Name = "Sinus Cap Red",
                UnitsInStock = 10,
                Chosen = true,
                Image = "https://db3pap001files.storage.live.com/y4pRdnHu8cnUZ2rL_7fstXl9s976FtRxkB_dTxsJASBbfMqFR8tK1TK_kFwgC_6p56Kq8HB3w_SgsZsN73QsRAEOnmUVIGWKL8Y5qd3BSNusQWwV2r721TlclNc2y_kzF_HkdbhRIgmVDOagHy7gXukvY462noV0DDWPQEasXNwb0AfCCzWiBfllXCO84NRs3m-qPlla_4A4kwnS6HXYExQnmuBQD2Yonzb0Ryrgptw2gA/sinus-hoodie-fire.png?psid=1&width=572&height=620"
            });

            ProductList.Add(new Boards
            {
                Price = 800,
                Id = 3,
                Category = Models.Enum.Category.Hoodie,
                Color = Models.Enum.Color.Grey,
                Description = "A gray sinus skateboard",
                Name = "Sinus Hoodie Grey",
                UnitsInStock = 10,
                Chosen = true,
                Image = "https://db3pap001files.storage.live.com/y4p1nNmxS802M9JxcKbcAFCepGWftkCqMk963nutiEWOdUv70wKq3RtnLUeFmA-BGCDoYfIvGvpSPdXPT48-ZL1daZ7QchMkoyHl5ZUKxs4-HfngzZfmkqnotPTs2d84SdFxy-tS4LDz2tGeMeowC1-2Rl7uALEtM_ihMjqagJzyBJ7jO4NnJ5lgd25H2253Cv7oDk3mDhkZFQV6KN31ICLu-tu6fEX61_E3KBRk8Z1ysk/sinus-hoodie-ash.png?psid=1&width=572&height=620",
                BoardSize = 8.5,
                Material = Models.Enum.Material.Wood
            });
            ProductList = ProductList.Where(p => p.Chosen).ToList();
        }
    }
}
