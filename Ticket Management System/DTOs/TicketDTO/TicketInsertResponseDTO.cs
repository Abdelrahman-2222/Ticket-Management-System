using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    public class TicketInsertResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string SupportAgentName { get; set; }

    }
}
