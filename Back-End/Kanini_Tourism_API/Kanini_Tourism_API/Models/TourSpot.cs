using System.ComponentModel.DataAnnotations;
namespace Kanini_Tourism_API.Models
{
   

    public class TourSpot
    {
        [Key]
        public int SpotId { get; set; }

        // Foreign key to the Tour table
      /*  public int TourId { get; set; }*/
        public Tour? Tour { get; set; }

        //[Required]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Spot Name must contain only alphabetic characters.")]
        public string? SpotName { get; set; }

        //[Required]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Speciality must contain only alphabetic characters.")]
        public string? Specialty { get; set; }


    }

}
