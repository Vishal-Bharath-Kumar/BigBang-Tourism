using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism_API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        //[Required (ErrorMessage = "Enter Username")]
        [StringLength(50)]
        public string? Username { get; set; }

        //[Required (ErrorMessage = "Enter Email")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? EmailId { get; set; }

        //[Required (ErrorMessage = "Enter Password")]
        [StringLength(100)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$", ErrorMessage = "Password must include at least one number, one special character, and have a minimum length of 8 characters.")]
        public string? Password { get; set; }

        //[Required (ErrorMessage = "Select Role")]
        public Role UserRole { get; set; }

        //[Required (ErrorMessage = "Select Status")]
        public Status UserStatus { get; set; }

        public static implicit operator string(User v)
        {
            throw new NotImplementedException();
        }

        public enum Role
        {
            Administrator,
            TravelAgent,
            Traveler
        }

        public enum Status
        {
            Active,
            Inactive
        }
    }
}
