using System.ComponentModel.DataAnnotations;
namespace Kanini_Tourism_API.Models
{


    public class TourHotelLink
    {
        [Key]
        public int LinkId { get; set; }

        // Foreign key to the Tour table
      /*  public int TourId { get; set; }*/
        public Tour? Tour { get; set; }

        // Foreign key to the Hotel table
     /*   public int HotelId { get; set; }*/
        public Hotel? Hotel { get; set; }
    }

}
