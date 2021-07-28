using CWExerciseWebApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWExerciseWebApi.Common.Authentication
{
    public interface IAuthenticationService
    {
        string CreateToken(LoginModel login);
    }
}
