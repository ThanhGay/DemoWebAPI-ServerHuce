using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Auth.Domain
{
    public class AuthCustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
    }
}
