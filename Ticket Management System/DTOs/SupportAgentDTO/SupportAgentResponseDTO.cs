using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.SupportAgentDTO
{
    public class SupportAgentResponseDTO
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public ICollection<TicketInsertResponseDTO> Tickets { get; set; }

    }
}
