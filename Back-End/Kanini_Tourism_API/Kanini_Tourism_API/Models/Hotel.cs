using System.ComponentModel.DataAnnotations;
namespace Kanini_Tourism_API.Models
{


    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        //[Required (ErrorMessage = "Enter Hotel Name")]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Hotel Name must contain only alphabetic characters.")]
        public string? HotelName { get; set; }

        //[Required (ErrorMessage = "Enter ImageUrl")]
        [StringLength(255)]
        public string? HotelImageUrl { get; set; }

        //[Required (ErrorMessage = "Enter Address")]
        [StringLength(100)]
        public string? Address { get; set; }

        //[Required(ErrorMessage = "Enter Hotel Location")]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Hotel Location must contain only alphabetic characters.")]
        public string? HotelLocation { get; set; }

        //[Required (ErrorMessage = "Enter Contact Info")]
        [StringLength(100)]
        public string? ContactInfo { get; set; }

        //[Required]
        [StringLength(255)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Hotel Description must contain only alphabetic characters.")]
        public string? Description { get; set; }

        /* //[Required (ErrorMessage = "Enter Hotel Price")]
         [Range(0, int.MaxValue)]
         public int HotelPrice { get; set; }*/

        // Foreign key to the TravelAgent table
        /*  public int AgentId { get; set; }*/
       
        public TravelAgent? TravelAgent { get; set; }
    }

}
