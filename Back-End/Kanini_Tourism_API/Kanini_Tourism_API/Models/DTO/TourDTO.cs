using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism_API.Models.DTO
{
    public class TourDTO
    {
        public int TourId { get; set; }

      

        public string? TourName { get; set; }

       

        public string? Description { get; set; }

      
        public int? TourPrice { get; set; }

        
        public string? TourImageUrl { get; set; }

        
        public string? TourLocation { get; set; }
        public TravelAgentDTO? TravelAgent { get; set; }
    }
}
