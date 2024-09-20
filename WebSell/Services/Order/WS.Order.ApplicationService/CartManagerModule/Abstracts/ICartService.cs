using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.Dtos.CartManagerModule;

namespace WS.Order.ApplicationService.CartManagerModule.Abstracts
{
    public interface ICartService
    {
        public void AddToCart(CreateCartDto input);
        public void RemoveFromCart(int cartId);
        public void IncreaseQuantity(int cartId);
        public void DecreaseQuantity(int cartId);
        public bool IsInStock(int productId, int userId);
        public CartDto GetCartByProductId(int productId, int userId);
    }
}
