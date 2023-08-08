using System.ComponentModel.DataAnnotations;
namespace Kanini_Tourism_API.Models
{


    public class Tour
    {
        [Key]
        public int TourId { get; set; }

        /*[Required (ErrorMessage = "Enter Tour Name")]*/
        [StringLength(100)]
      //  [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Tour Name must contain only alphabetic characters.")]
        public string? TourName { get; set; }

       /* //[Required (ErrorMessage = "Enter Description")]*/
        [StringLength(255)]
        public string? Description { get; set; }

       /* //[Required (ErrorMessage = "Enter Tour Price")]*/
        [Range(0, int.MaxValue)]
        public int? TourPrice { get; set; }

        //[Required (ErrorMessage = "Enter Tour ImageUrl")]
        [StringLength(255)]
        public string? TourImageUrl { get; set; }

        //[Required(ErrorMessage = "Enter Tour Location")]
        [StringLength(100)]
       // [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Tour Location must contain only alphabetic characters.")]
        public string? TourLocation { get; set; }


        // Foreign key to the TravelAgent table
     /*   public int AgentId { get; set; }*/
        public TravelAgent? TravelAgent { get; set; }
    }

}
