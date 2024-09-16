using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.ApplicationService.Common;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.Domain;
using WS.Product.Dtos.Common;
using WS.Product.Dtos.ProductManagerModule;
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

        public void CreateProduct(CreateProductDto input)
        {
            var existProduct = _dbContext.Products.Any(prod => prod.Name == input.Name);
            if (!existProduct)
            {
                var newProduct = new ProdProduct()
                {
                    Name = input.Name,
                    Price = input.Price,
                    Quantity = input.Quantity,
                    Description = input.Description,
                };

                _dbContext.Products.Add(newProduct);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Đã tồn tại sản phẩm có tên: {input.Name}.");
            }
        }

        public void DeleteProduct(int id)
        {
            var existProduct = _dbContext.Products.FirstOrDefault(prod => prod.Id == id);
            if (existProduct != null)
            {
                _dbContext.Products.Remove(existProduct);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tìm thấy sản phẩm có Id: {id}.");
            }
        }

        public ProductDto Get(int id)
        {
            var existProduct = _dbContext.Products.FirstOrDefault(prod => prod.Id == id);

            if (existProduct != null)
            {
                var returnProduct = new ProductDto()
                {
                    Id = existProduct.Id,
                    Name = existProduct.Name,
                    Price = existProduct.Price,
                    Quantity = existProduct.Quantity,
                    Description = existProduct.Description,
                };

                return returnProduct;
            }
            else
            {
                throw new Exception($"Không tìm thấy sản phẩm có Id: {id}.");
            }
        }

        public PageResultDto<ProductDto> GetAll(FilterDto input)
        {
            var result = new PageResultDto<ProductDto>();

            var productQuery = _dbContext.Products.Select(s => new ProductDto
            {
                Name = s.Name,
                Price = s.Price,
                Quantity = s.Quantity,
                Description = s.Description,
            });

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                productQuery = productQuery.Where(s => s.Name.ToLower().Contains(input.Keyword.ToLower()));
            }

            int totalItems = productQuery.Count();

            productQuery = productQuery.Skip(input.SkipCount()).Take(input.PageSize);

            result.Items = productQuery;
            result.TotalItem = totalItems;

            return result;
        }

        public void UpdateProduct(UpdateProductDto input)
        {
            var existProduct = _dbContext.Products.FirstOrDefault(prod => prod.Id == input.Id);
            var existProductName = _dbContext.Products.Any(prod => prod.Name == input.Name && prod.Id != input.Id);

            if (!existProductName)
            {
                if (existProduct != null)
                {
                    existProduct.Name = input.Name;
                    existProduct.Description = input.Description;
                    existProduct.Price = input.Price;

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception($"Không tìm thấy sản phẩm có Id: {input.Id}.");
                }
            }
            else
            {
                throw new Exception($"Đã tòn tại sản phẩm có tên \"{input.Name}\"");
            }
        }
    }
}
