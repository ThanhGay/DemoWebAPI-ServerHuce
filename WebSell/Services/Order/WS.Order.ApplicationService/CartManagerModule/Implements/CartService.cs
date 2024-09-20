using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.ApplicationService.CartManagerModule.Abstracts;
using WS.Order.ApplicationService.Common;
using WS.Order.Domain;
using WS.Order.Dtos.CartManagerModule;
using WS.Order.Infrastructures;
using WS.Shared.ApplicationService.Product;
using WS.Shared.ApplicationService.User;

namespace WS.Order.ApplicationService.CartManagerModule.Implements
{
    public class CartService : OrderServiceBase, ICartService
    {
        private readonly IUserInforService _userInforService;
        private readonly IProductInforService _productInforService;

        public CartService(ILogger logger, OrderDbContext dbContext, IUserInforService userInforService, IProductInforService productInforService) : base(logger, dbContext)
        {
            _userInforService = userInforService;
            _productInforService = productInforService;
        }

        public void AddToCart(CreateCartDto input)
        {
            var existProduct = _productInforService.HasProduct(input.ProductId);
            if (existProduct)
            {
                var newItem = new OrdCart
                {
                    ProductId = input.ProductId,
                    Quantity = input.Quantity,
                    UserId = input.UserId,
                };

                _dbContext.Carts.Add(newItem);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tại sản phẩm có Id: {input.ProductId}");
            }
        }

        public void DecreaseQuantity(int cartId)
        {
            var existCartItem = _dbContext.Carts.FirstOrDefault(c => c.Id == cartId);
            if (existCartItem != null)
            {
                if (existCartItem.Quantity > 1)
                {
                    existCartItem.Quantity -= 1;
                }
                else
                {
                    _dbContext.Carts.Remove(existCartItem);
                };

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tìm thấy giỏ hàng có Id \"{cartId}\"");
            }
        }

        public void IncreaseQuantity(int cartId)
        {
            var existCartItem = _dbContext.Carts.FirstOrDefault(c => c.Id == cartId);
            if (existCartItem != null)
            {
                existCartItem.Quantity += 1;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tìm thấy giỏ hàng có Id \"{cartId}\"");
            }
        }

        public void RemoveFromCart(int cartId)
        {
            var existCartItem = _dbContext.Carts.FirstOrDefault(c => c.Id == cartId);
            if (existCartItem != null)
            {
                _dbContext.Carts.Remove(existCartItem);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tìm thấy giỏ hàng có Id \"{cartId}\"");
            }
        }

        public bool IsInStock(int productId, int userId)
        {
            return _dbContext.Carts.Any(c => c.ProductId == productId && c.UserId == userId);
        }

        public CartDto GetCartByProductId(int productId, int userId)
        {
            var foundedCart = _dbContext.Carts.FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);
            if (foundedCart != null)
            {

                var rtnCart = new CartDto()
                {
                    Id = foundedCart.Id,
                    UserId = userId,
                    Quantity = foundedCart.Quantity,
                };
                return rtnCart;
            }
            else
            {
                throw new Exception($"Không thấy sp trong giỏ");
            }
        }
    }
}
