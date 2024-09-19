using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Shared.Constant.Database;

namespace WS.Order.Domain
{
    [Table(nameof(OrderPurchase), Schema = DbSchema.Order)]
    public class OrderPurchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
    }
}
