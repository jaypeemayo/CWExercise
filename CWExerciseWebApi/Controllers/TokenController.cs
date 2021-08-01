using CWExerciseWebApi.Common.Authentication;
using CWExerciseWebApi.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CWExerciseWebApi.Controllers
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
		public IActionResult CreateToken([FromBody] LoginModel login)
		{
			IActionResult response = Unauthorized();
			var tokenString = authenticationService.CreateToken(login);
			if (tokenString != null)
			{
				response = Ok(new { token = tokenString });
			}
			return response;
		}
	}
}
