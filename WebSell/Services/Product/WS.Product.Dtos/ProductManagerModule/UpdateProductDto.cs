using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Product.Dtos.ProductManagerModule
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được để trống")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Giá cả không được bé hơn 0")]
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
