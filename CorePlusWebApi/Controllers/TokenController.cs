using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWExerciseApi.BLL;
using CWExerciseApi.BLL.Services;
using CorePlusWebApi.Common.Authentication;
using CorePlusWebApi.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CorePlusWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IAuthenticationService authenticationService;

        public TokenController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var tokenString = authenticationService.CreateToken(login);
            if(tokenString != null)
            {
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
