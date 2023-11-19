using backend_auth.Interfaces;
using backend_auth.Models;
using backend_auth.Models.Requests;
using backend_auth.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace backend_auth.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> _logger;
		private readonly IAuthService _authService;

		public AuthController(ILogger<AuthController> logger, IAuthService authService)
		{
			_logger = logger;
			_authService = authService;
		}

		[HttpPost]
		[Route("Authenticate")]
		public UserResponse Authenticate(UserRequest request)
		{
			User? user = _authService.Authenticate(request);

			UserResponse response = new UserResponse();
			if (user != null)
			{
				string token = _authService.GenerateJwtToken(user);
				response = new UserResponse(user, token);
			}

			return response;
		}
	}
}