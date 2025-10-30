using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.DTOs.TicketPriorityDTO
{
    public class TicketPriorityAllDetailsResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TicketGetForStatusDTO> Tickets { get; set; } = new();
    }
}
