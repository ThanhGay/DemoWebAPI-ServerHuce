using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Order.Dtos.OrderManagerModule
{
    public class CreateOrderDto
    {
        public int UsertId { get; set; }
        public required int[] OrderIds { get; set; }
    }
}
