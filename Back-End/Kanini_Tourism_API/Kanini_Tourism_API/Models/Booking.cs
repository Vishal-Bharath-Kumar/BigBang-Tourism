using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Tourism_API.Models
{


    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        // Foreign key to the User table
       /* [ForeignKey("UserId")]
        public int UserId { get; set; }*/
        public User? User { get; set; }

        // Foreign key to the Tour table
      /*  [ForeignKey("TourId")]
        public int TourId { get; set; }*/
        public Tour? Tour { get; set; }

        // Foreign key to the Hotel table
       /* [ForeignKey("HotelId")]
        public int HotelId { get; set; }*/
        public Hotel? Hotel { get; set; }

        //[Required (ErrorMessage = "Enter Booking date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }

        //[Required (ErrorMessage = "Enter Total Price")]
        [Range(0, int.MaxValue)]
        public int TotalPrice { get; set; }
    }

}
