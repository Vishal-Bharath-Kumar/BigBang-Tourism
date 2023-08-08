using System;
using System.ComponentModel.DataAnnotations;
namespace Kanini_Tourism_API.Models
{


    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        // Foreign key to the User table
        public int UserId { /**/get; set; }
        public User? User { get; set; }

        //[Required (ErrorMessage = "Enter Feedback")]
        [StringLength(100)]
        public string? FeedbackText { get; set; }

        //[Required (ErrorMessage = "Enter Feedback Date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FeedbackDate { get; set; }
    }

}
