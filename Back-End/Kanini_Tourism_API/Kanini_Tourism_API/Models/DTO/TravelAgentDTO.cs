using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism_API.Models.DTO
{
    public class TravelAgentDTO
    {
      
        public int AgentId { get; set; }

       
        public string? AgencyName { get; set; }

       
        public string? AgentImageUrl { get; set; }

       
        public string? ContactInfo { get; set; }

        
        public int Rating { get; set; }

        public ApprovalStatus Status { get; set; }

        public User? User { get; set; }

        public enum ApprovalStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
}
