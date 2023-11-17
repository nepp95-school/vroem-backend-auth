using backend_auth.Models;
using backend_auth.Models.Requests;

namespace backend_auth.Interfaces
{
	public interface IAuthService
	{
		public User? Authenticate(UserRequest request);
		public string GenerateJwtToken(User user);
	}
}
