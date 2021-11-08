using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class Enum
    {
        public enum Category
        {
            Cap,
            Hoodie,
            Skateboard,
            Tshirt,
            Wheel,
            Shoes
        }

        public enum Color
        {
            Blue,
            Green,
            Grey,
            Patterned,
            Pink,
            Purple,
            Red,
            White,
            Yellow
        }

        public enum Size
        {
            [Display(Name = "One size")]
            One_size,
            S,
            M,
            L
        }

        public enum Material
        {
            Plastic,
            Wood
        }
    }
}
