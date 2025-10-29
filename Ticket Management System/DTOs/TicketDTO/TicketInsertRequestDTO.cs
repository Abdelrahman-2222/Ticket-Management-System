using Ticket_Management_System.DTOs.TicketCommentDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    public class TicketInsertRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int? SupportAgentId { get; set; }
        public int TicketCategoryId { get; set; }
        public ICollection<TicketCommentInsertRequestDTO> Comments { get; set; }

    }
}
