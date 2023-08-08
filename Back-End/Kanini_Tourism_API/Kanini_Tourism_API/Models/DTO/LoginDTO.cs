using static Kanini_Tourism_API.Models.User;

namespace Kanini_Tourism_API.Models.DTO
{
    public class LoginDTO
    {
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}
