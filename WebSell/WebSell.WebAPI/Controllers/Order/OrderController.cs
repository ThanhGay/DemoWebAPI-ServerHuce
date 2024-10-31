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

        [HttpGet("/cart/get/{cardId}")]
        public IActionResult GetCart(int cardId)
        {
            try
            {
                return Ok(_cartService.GetById(cardId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPut("/cart/increase/{id}")]
        public IActionResult IncreaseQuantity(int id)
        {
            try
            {
                _cartService.IncreaseQuantity(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/cart/decrease/{id}")]
        public IActionResult DecreaseQuantity(int id)
        {
            try
            {
                _cartService.DecreaseQuantity(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/cart/delete/{id}")]
        public IActionResult DeleteCart(int id)
        {
            try
            {
                _cartService.RemoveFromCart(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/order/detail/{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                return Ok(_orderService.GetDetail(id));
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
                return Ok();
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
            }
            ;
        }

        [HttpDelete("/order/delete/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
