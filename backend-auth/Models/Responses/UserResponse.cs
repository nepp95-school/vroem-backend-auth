namespace backend_auth.Models.Responses
{
	public class UserResponse
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Token { get; set; }

		public UserResponse(User user, string token)
		{
			Id = user.Id;
			Username = user.Username;
			Token = token;
		}
	}
}
