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
    [Table(nameof(ProdProduct), Schema = DbSchema.Product)]
    public class ProdProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
