using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.Domain;
using WS.Order.Dtos.CartManagerModule;

namespace WS.Order.ApplicationService.CartManagerModule.Abstracts
{
    public interface ICartService
    {
        public void AddToCart(CreateCartDto input);
        public void RemoveFromCart(int id);
        public void IncreaseQuantity(int id);
        public void DecreaseQuantity(int id);
        public bool IsInStock(int productId, int userId);
        public CartDto GetByProductId(int productId, int userId);
        public OrdCart GetById(int id);
        public void DeleteCart(int id);
    }
}
