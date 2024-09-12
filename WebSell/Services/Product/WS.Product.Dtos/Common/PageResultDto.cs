using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Product.Dtos.Common
{
    public class PageResultDto<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int TotalItem { get; set; }
    }
}
