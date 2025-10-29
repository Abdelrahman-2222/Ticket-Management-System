using Microsoft.Identity.Client;

namespace Ticket_Management_System.DTOs.TicketStatusDTO
{
    public class TicketStatusResponseDTO
    {
        public int Id { get; set; }

        public string TicketStatusName { get; set; }
    }
}
