using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Models
{
    public class Shoes
    {
        public int ShoesId { get; set; }
        public string ShoesName { get; set; }

        public string imageUrl { get; set; }
        public float Price { get; set; }

        public int CategoryNo { get; set; }
        public string Gender { get; set; }
    }
}
