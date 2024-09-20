using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.Dtos.OrderManagerModule;

namespace WS.Order.ApplicationService.OrderManagerModule.Abstracts
{
    public interface IOrderService
    {
        public void CreateOrder(CreateOrderDto input);
        public void UpdateOrder(UpdateOrderDto input);
        public void DeleteOrder(int id);

    }
}
