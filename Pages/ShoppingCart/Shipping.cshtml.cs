using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SkateShop.Pages.ShoppingCart
{
    public class ShippingModel : PageModel
    {
        [BindProperty, Required]
        public string FirstName { get; set; }
        [BindProperty, Required]
        public string LastName { get; set; }
        [BindProperty, Required]
        public string Address { get; set; }
        [BindProperty, Required]
        public string PhoneNumber { get; set; }

        [BindProperty, Required]
        public double FreightCost { get; set; }
        public double[] FreightOptions = new[] { 0, 49.0, 79.0 };


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var orderInfo = new Models.OrderModel
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Address = Address,
                    PhoneNumber = PhoneNumber,
                    FreightCost = FreightCost
                };
                return RedirectToPage("/ShoppingCart/Payment", orderInfo);
            }
            return Page();
        }
    }
}
