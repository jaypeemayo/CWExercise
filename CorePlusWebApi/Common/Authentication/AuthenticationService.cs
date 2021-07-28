using CorePlusWebApi.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlusWebApi.Common.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration config;

        public AuthenticationService(IConfiguration config)
        {
            this.config = config;
        }
        public string CreateToken(LoginModel login)
        {
            var user = Authenticate(login);

            if (user != null)
            {
                return BuildToken(user);
            }

            return null;
        }

        private string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login.Username == "admin" && login.Password == "TestPass!123")
            {
                user = new UserModel { Name = "admin", Email = "admin@gg.com" };
            }
            return user;
        }
    }
}
