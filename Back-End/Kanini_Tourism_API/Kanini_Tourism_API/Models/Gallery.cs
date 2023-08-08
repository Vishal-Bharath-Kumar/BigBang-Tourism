using System;
using System.ComponentModel.DataAnnotations;
namespace Kanini_Tourism_API.Models
{


    public class Gallery
    {
        [Key]
        public int ImageId { get; set; }

        // Foreign key to the User table
       /* public int UserId { get; set; }*/
        public User? User { get; set; }

        //[Required (ErrorMessage = "Enter ImageUrl")]
        [StringLength(255)]
        public string? ImageUrl { get; set; }

       
    }

}
