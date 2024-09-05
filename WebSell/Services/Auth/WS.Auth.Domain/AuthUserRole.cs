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
    [Table(nameof(AuthUserRole), Schema = DbSchema.Auth)]
    public class AuthUserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
