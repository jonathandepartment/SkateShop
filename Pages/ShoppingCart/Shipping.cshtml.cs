using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SkateShop.Pages.ShoppingCart
{
    public class ShippingModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public double FreightCost { get; set; }
        public void OnGet()
        {

        }
    }
}
