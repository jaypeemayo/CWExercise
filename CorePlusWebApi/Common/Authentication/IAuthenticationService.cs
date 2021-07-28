using CorePlusWebApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlusWebApi.Common.Authentication
{
    public interface IAuthenticationService
    {
        string CreateToken(LoginModel login);
    }
}
