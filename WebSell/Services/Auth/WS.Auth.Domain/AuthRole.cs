using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Shared.Constant.Database;

namespace WS.Auth.Domain
{
    [Table(nameof(AuthRole), Schema = DbSchema.Auth)]
    public class AuthRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
