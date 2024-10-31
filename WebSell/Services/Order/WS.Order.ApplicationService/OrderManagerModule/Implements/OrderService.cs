using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WS.Order.ApplicationService.CartManagerModule.Abstracts;
using WS.Order.ApplicationService.Common;
using WS.Order.ApplicationService.OrderManagerModule.Abstracts;
using WS.Order.Domain;
using WS.Order.Dtos.Common;
using WS.Order.Dtos.OrderManagerModule;
using WS.Order.Infrastructures;
using WS.Shared.ApplicationService.Product;
using WS.Shared.ApplicationService.User;

namespace WS.Order.ApplicationService.OrderManagerModule.Implements
{
    public class OrderService : OrderServiceBase, IOrderService
    {
        private readonly IUserInforService _userInforService;
        private readonly IProductInforService _productInforService;
        private readonly ICartService _cartService;

        public OrderService(
            ILogger<OrderService> logger,
            OrderDbContext dbContext,
            ICartService cartService,
            IUserInforService userInforService,
            IProductInforService productInforService
        )
            : base(logger, dbContext)
        {
            _cartService = cartService;
            _userInforService = userInforService;
            _productInforService = productInforService;
        }

        public void CreateOrder(CreateOrderDto input)
        {
            foreach (var item in input.CartIds)
            {
                var existItem = _cartService.IsInStock(item, input.UsertId);
                if (existItem)
                {
                    Console.WriteLine("pass");
                    continue;
                }
                else
                {
                    throw new Exception(
                        $"Không tồn tại sản phẩm có Id \"{item}\" trong giỏ hàng của bạn."
                    );
                }
            }

            // If pass all item
            var newOrder = new OrdOrder
            {
                UserId = input.UsertId,
                CreatedDate = DateTime.Now,
                Status = 0,
            };

            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();

            foreach (var item in input.CartIds)
            {
                var itemCart = _cartService.GetByProductId(item, input.UsertId);
                var newItem = new OrdOrderDetail
                {
                    ProductId = item,
                    Quantity = itemCart.Quantity,
                    OrderId = newOrder.Id,
                };

                _cartService.DeleteCart(itemCart.Id);
                _dbContext.OrderDetails.Add(newItem);
            }
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var haveOrderItem = _dbContext.Orders.Any(ord => ord.Id == id);
            if (haveOrderItem)
            {
                var orderDetailItems = _dbContext.OrderDetails.Where(od => od.OrderId == id);
                foreach (var item in orderDetailItems)
                {
                    _dbContext.OrderDetails.Remove(item);
                    _dbContext.SaveChanges();
                }
                var existOrder = _dbContext.Orders.FirstOrDefault(ord => ord.Id == id);

                if (existOrder != null)
                {
                    _dbContext.Orders.Remove(existOrder);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception($"Đơn hàng có Id \"{id}\" của bạn không tồn tại");
                }
            }
            else
            {
                throw new Exception($"Đơn hàng có Id \"{id}\" của bạn không tồn tại");
            }
        }

        public PageResultDto<DetailOrderItemDto> GetDetail(int orderId)
        {
            var result = new PageResultDto<DetailOrderItemDto>();

            var existOrder = _dbContext.OrderDetails.Any(o => o.OrderId == orderId);
            if (existOrder)
            {
                var listProd = new List<DetailOrderItemDto>();
                var query = _dbContext.OrderDetails.Where(o => o.OrderId == orderId).Select(c => new { c.Quantity, c.ProductId}).ToList();
                foreach (var item in query)
                {
                    var prod = _productInforService.GetProduct(item.ProductId);
                    listProd.Add(new DetailOrderItemDto
                    {
                        ProductId = item.ProductId,
                        ProductName = prod.Name,
                        Quantity = item.Quantity,
                    });
                }

                result.Items = listProd;
                result.TotalItem = listProd.Count();

                return result;
            }
            else
            {
                throw new Exception($"Đơn hàng \"{orderId}\" của bạn không tồn tại");
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
