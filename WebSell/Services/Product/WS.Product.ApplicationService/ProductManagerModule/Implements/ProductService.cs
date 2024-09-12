using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.ApplicationService.Common;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.Infrastructures;
using WS.Shared.ApplicationService.User;

namespace WS.Product.ApplicationService.ProductManagerModule.Implements
{
    public class ProductService : ProductServiceBase, IProductService
    {
        private readonly IUserInforService _userInforService;
        public ProductService(ILogger<ProductService> logger, ProductDbContext dbContext, IUserInforService userInforService) : base(logger, dbContext)
        {
            _userInforService = userInforService;
        }
    }
}
