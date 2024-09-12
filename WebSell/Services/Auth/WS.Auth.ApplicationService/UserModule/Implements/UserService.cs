using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Auth.ApplicationService.Common;
using WS.Auth.ApplicationService.UserModule.Abstracts;
using WS.Auth.Dtos.UserModule;
using WS.Auth.Infrastructures;

namespace WS.Auth.ApplicationService.UserModule.Implements
{
    public class UserService : AuthServiceBase, IUserService
    {
        public UserService(ILogger<UserService> logger, AuthDbContext dbContext) : base(logger, dbContext)
        {
        }

        public void CreateUser(CreateUserDto input)
        {
            //_dbContext.Users.Add();
        }
    }
}
