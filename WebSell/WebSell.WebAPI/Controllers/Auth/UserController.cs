using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Auth.ApplicationService.UserModule.Abstracts;
using WS.Auth.Dtos.UserModule;

namespace WebSell.WebAPI.Controllers.Auth
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Thêm user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult CreateUser(CreateUserDto input)
        {
            _userService.CreateUser(input);
            return Ok();
        }
    }
}
