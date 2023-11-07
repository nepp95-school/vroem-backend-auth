using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using backend_auth.Interfaces;
using backend_auth.Models;
using backend_auth.Models.Requests;

namespace backend_auth.Services
{
	public class AuthService : IAuthService
	{
		private readonly IConfigurationBuilder _configBuilder = new ConfigurationBuilder();
		private string _token;

		private List<User> _users = new List<User>
		{
			new User { Id = 1, Username = "Niels", Password = "Abc" }
		};

		public AuthService()
		{
			_configBuilder.AddJsonFile("appsettings.json");
			IConfiguration configuration = _configBuilder.Build();
			_token = configuration["Jwt:Key"];
		}

		public User? Authenticate(UserRequest request)
		{
			return _users.SingleOrDefault(x => x.Username == request.Username && x.Password == request.Password);
		}

		public string GenerateJwtToken(User user)
		{
			// generate token that is valid for 7 days
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_token);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
