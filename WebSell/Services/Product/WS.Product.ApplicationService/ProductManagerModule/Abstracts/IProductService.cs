using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.Domain;
using WS.Product.Dtos.Common;
using WS.Product.Dtos.ProductManagerModule;

namespace WS.Product.ApplicationService.ProductManagerModule.Abstracts
{
    public interface IProductService
    {
        public void CreateProduct(CreateProductDto input);
        public void UpdateProduct(UpdateProductDto input);
        public void DeleteProduct(int id);
        public PageResultDto<ProductDto> GetAll(FilterDto input);
        public ProductDto Get(int id);
    }
}
