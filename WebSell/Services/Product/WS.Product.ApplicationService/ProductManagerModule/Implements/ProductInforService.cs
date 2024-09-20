using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.ApplicationService.Common;
using WS.Product.Dtos.ProductManagerModule;
using WS.Product.Infrastructures;
using WS.Shared.ApplicationService.Product;
using WS.Shared.ApplicationService.User;

namespace WS.Product.ApplicationService.ProductManagerModule.Implements
{
    public class ProductInforService : ProductServiceBase, IProductInforService
    {
        private IUserInforService _userInforService;

        public ProductInforService(ILogger<ProductInforService> logger, ProductDbContext dbContext, IUserInforService userInforService) : base(logger, dbContext)
        {
            _userInforService = userInforService;
        }

        //public ProductDto GetProduct(int id)
        //{
        //    var existProduct = _dbContext.Products.FirstOrDefault(prod => prod.Id == id);

        //    if (existProduct != null)
        //    {
        //        var returnProduct = new ProductDto()
        //        {
        //            Id = existProduct.Id,
        //            Name = existProduct.Name,
        //            Price = existProduct.Price,
        //            Quantity = existProduct.Quantity,
        //            Description = existProduct.Description,
        //        };

        //        return returnProduct;
        //    }
        //    else
        //    {
        //        throw new Exception($"Không tìm thấy sản phẩm có Id: {id}.");
        //    }
        //}

        public bool HasProduct(int id)
        {
            return _dbContext.Products.Any(prod => prod.Id == id);
        }
    }
}
