using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.ApplicationService.CartManagerModule.Abstracts;
using WS.Order.ApplicationService.Common;
using WS.Order.ApplicationService.OrderManagerModule.Abstracts;
using WS.Order.Domain;
using WS.Order.Dtos.OrderManagerModule;
using WS.Order.Infrastructures;
using WS.Shared.ApplicationService.User;

namespace WS.Order.ApplicationService.OrderManagerModule.Implements
{
    public class OrderService : OrderServiceBase, IOrderService
    {
        private readonly IUserInforService _userInforService;
        private readonly ICartService _cartService;
        public OrderService(ILogger<OrderService> logger, OrderDbContext dbContext, ICartService cartService, IUserInforService userInforService) : base(logger, dbContext)
        {
            _cartService = cartService;
            _userInforService = userInforService;
        }

        public void CreateOrder(CreateOrderDto input)
        {
            foreach (var item in input.OrderIds)
            {
                var existItem = _cartService.IsInStock(item, input.UsertId);
                if (existItem)
                {
                    continue;
                }
                else
                {
                    throw new Exception($"Không tồn tại sản phẩm có Id \"{item}\" trong giỏ hàng của bạn.");
                }
            }

            // If pass all item
            var newOrder = new OrdOrder
            {
                UserId = input.UsertId,
                CreatedDate = DateTime.Now,
                Status = 0,
            };
            // Làm sao để trả ra Id nhằm tạo OrderId ????
            foreach (var item in input.OrderIds)
            {
                var itemCart = _cartService.GetCartByProductId(item, input.UsertId);
                var newItem = new OrdOrderDetail
                {
                    ProductId = item,
                    Quantity = itemCart.Quantity,
                    OrderId = itemCart.Id
                };
                _dbContext.OrderDetails.Add(newItem);
                _dbContext.SaveChanges();

            }
        }

        public void DeleteOrder(int id)
        {
            var existOrder = _dbContext.Orders.FirstOrDefault(ord => ord.Id == id);
            if (existOrder != null)
            {
                _dbContext.Orders.Remove(existOrder);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Đơn hàng \"{id}\" của bạn không tồn tại");
            }
        }

        public void UpdateOrder(UpdateOrderDto input)
        {
            var existOrder = _dbContext.Orders.FirstOrDefault(ord => ord.Id == input.Id);
            if (existOrder != null)
            {
                existOrder.Status = input.Status;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Đơn hàng \"{input.Id}\" của bạn không tôn tại");
            }
        }
    }
}
