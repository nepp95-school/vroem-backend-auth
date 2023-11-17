using System.ComponentModel.DataAnnotations;

namespace backend_auth.Models.Requests
{
	public class UserRequest
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		public UserRequest(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}
