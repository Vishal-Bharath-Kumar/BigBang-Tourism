using System.ComponentModel.DataAnnotations;
namespace Kanini_Tourism_API.Models
{


    public class TravelAgent
    {
        [Key]
        public int AgentId { get; set; }

        //[Required (ErrorMessage = "Enter Agency Name")]
        //[StringLength(100)]
        //[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Agency Name must contain only alphabetic characters.")]
        public string? AgencyName { get; set; }

        //[Required (ErrorMessage = "Enter ImageUrl")]
       // [StringLength(255)]
        public string? AgentImageUrl { get; set; }

        //[Required (ErrorMessage = "Enter Contact Info")]
       // [StringLength(255)]
        public string? ContactInfo { get; set; }

        //[Required (ErrorMessage = "Enter Ratings")]
       // [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }

        //[Required (ErrorMessage = "Select Status")]
        public ApprovalStatus Status { get; set; }

        // Foreign key to the User table
       /* public int UserId { get; set; }*/
        public User? User { get; set; }

        public enum ApprovalStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }

}
