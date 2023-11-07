using System.ComponentModel.DataAnnotations;

namespace backend_auth.Models.Requests
{
    public class UserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}