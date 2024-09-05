using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Shared.Constant.Database;

namespace WS.Product.Domain
{
    [Table(nameof(ProdProductCategory), Schema = DbSchema.Product)]
    public class ProdProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
