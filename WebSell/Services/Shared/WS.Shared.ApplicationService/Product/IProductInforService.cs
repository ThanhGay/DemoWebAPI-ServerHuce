using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.Dtos.ProductManagerModule;

namespace WS.Shared.ApplicationService.Product
{
    public interface IProductInforService
    {
        public ProductDto GetProduct(int id);
        public bool HasProduct (int id);
    }
}
