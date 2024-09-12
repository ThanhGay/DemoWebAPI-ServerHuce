using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Product.Dtos.ProductManagerModule
{
    public class ProductDto
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
