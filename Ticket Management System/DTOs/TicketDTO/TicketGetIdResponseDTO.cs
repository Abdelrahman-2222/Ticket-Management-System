using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketCategoryDTO;
using Ticket_Management_System.DTOs.TicketPriorityDTO;
using Ticket_Management_System.DTOs.TicketStatusDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    public class TicketGetIdResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTimeOffset? SubmittedAt { get; set; } = DateTimeOffset.Now;
        public SupportAgentResponseDTO SupportAgentName { get; set; }
        public EmployeeResponseDTO EmployeeName { get; set; }
        public TicketStatusResponseDTO TicketStatus { get; set; }
        public TicketPriorityResponseDTO TicketPriority { get; set; }
        public TicketCategoryResponseDTO TicketCategory { get; set; }
    }
}
