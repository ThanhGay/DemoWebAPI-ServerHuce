using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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

        public CartService(
            ILogger<CartService> logger,
            OrderDbContext dbContext,
            IUserInforService userInforService,
            IProductInforService productInforService
        )
            : base(logger, dbContext)
        {
            _userInforService = userInforService;
            _productInforService = productInforService;
        }

        public void AddToCart(CreateCartDto input)
        {
            var existProduct = _productInforService.HasProduct(input.ProductId);
            var existItem = _dbContext.Carts.FirstOrDefault(c =>
                c.ProductId == input.ProductId && c.UserId == input.UserId
            );
            if (existProduct)
            {
                if (existItem != null)
                {
                    existItem.Quantity += input.Quantity;
                }
                else
                {
                    var newItem = new OrdCart
                    {
                        ProductId = input.ProductId,
                        Quantity = input.Quantity,
                        UserId = input.UserId,
                    };

                    _dbContext.Carts.Add(newItem);
                }
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tại sản phẩm có Id: {input.ProductId}");
            }
        }

        public void DecreaseQuantity(int id)
        {
            var existCartItem = _dbContext.Carts.FirstOrDefault(c => c.Id == id);
            if (existCartItem != null)
            {
                if (existCartItem.Quantity > 1)
                {
                    existCartItem.Quantity -= 1;
                }
                else
                {
                    _dbContext.Carts.Remove(existCartItem);
                }
                ;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tìm thấy giỏ hàng có Id \"{id}\"");
            }
        }

        public void IncreaseQuantity(int id)
        {
            var existCartItem = _dbContext.Carts.FirstOrDefault(c => c.Id == id);
            if (existCartItem != null)
            {
                existCartItem.Quantity += 1;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tìm thấy giỏ hàng có Id \"{id}\"");
            }
        }

        public void RemoveFromCart(int id)
        {
            var existCartItem = _dbContext.Carts.FirstOrDefault(c => c.Id == id);
            if (existCartItem != null)
            {
                _dbContext.Carts.Remove(existCartItem);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tồn tìm thấy giỏ hàng có Id \"{id}\"");
            }
        }

        public bool IsInStock(int productId, int userId)
        {
            return _dbContext.Carts.Any(c => c.ProductId == productId && c.UserId == userId);
        }

        public CartDto GetByProductId(int productId, int userId)
        {
            var foundedCart = _dbContext.Carts.FirstOrDefault(c =>
                c.ProductId == productId && c.UserId == userId
            );
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

        public OrdCart GetById(int id)
        {
            var existCart = _dbContext.Carts.FirstOrDefault(c => c.Id == id);
            if (existCart != null)
            {
                return existCart;
            }
            else
            {
                throw new Exception($"Không tìm thấy cart có Id: {id}");
            }
        }

        public void DeleteCart(int id)
        {
            var existCart = _dbContext.Carts.FirstOrDefault(c => c.Id == id);
            if (existCart != null)
            {
                _dbContext.Carts.Remove(existCart);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tìm thấy cart có Id: {id}");
            }
        }
    }
}
