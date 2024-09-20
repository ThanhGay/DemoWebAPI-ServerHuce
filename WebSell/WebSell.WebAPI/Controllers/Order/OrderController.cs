using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Order.ApplicationService.CartManagerModule.Abstracts;
using WS.Order.ApplicationService.OrderManagerModule.Abstracts;
using WS.Order.Dtos.CartManagerModule;
using WS.Order.Dtos.OrderManagerModule;

namespace WebSell.WebAPI.Controllers.Order
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public OrderController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }

        [HttpPost("/cart/add")]
        public IActionResult CreateCart(CreateCartDto input)
        {
            try
            {
                _cartService.AddToCart(input);
                return Ok("Thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/cart/increase/{cartId}")]
        public IActionResult IncreaseQuantity(int cartId)
        {
            try
            {
                _cartService.IncreaseQuantity(cartId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/cart/decrease/{cartId}")]
        public IActionResult DecreaseQuantity(int cartId)
        {
            try
            {
                _cartService.DecreaseQuantity(cartId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/cart/delete/{id}")]
        public IActionResult DeleteCart(int cartId)
        {
            try
            {
                _cartService.RemoveFromCart(cartId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/order/create")]
        public IActionResult CreateOrder(CreateOrderDto input)
        {
            try
            {
                _orderService.CreateOrder(input);
                return Ok("Sowe thing wents wrong.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/order/update")]
        public IActionResult UpdateOrder(UpdateOrderDto input)
        {
            try
            {
                _orderService.UpdateOrder(input);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
    }
}
