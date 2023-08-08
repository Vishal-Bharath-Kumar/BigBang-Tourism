using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism_API.Models.DTO
{
    public class UserStatusDTO
    {
     
        public int UserId { get; set; }

        public Status? UserStatus { get; set; }

   

        public enum Status
        {
            Active,
            Inactive
        }
    }
}
