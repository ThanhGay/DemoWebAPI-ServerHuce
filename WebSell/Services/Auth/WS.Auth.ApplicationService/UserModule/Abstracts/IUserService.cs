using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Auth.Dtos.UserModule;

namespace WS.Auth.ApplicationService.UserModule.Abstracts
{
    public interface IUserService
    {
        void CreateUser(CreateUserDto input);
    }
}
