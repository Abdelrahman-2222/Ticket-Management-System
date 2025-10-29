using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.DTOs.TicketCategoryDTO
{
    public class TicketCategoryResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TicketInsertResponseDTO> Tickets { get; set; }
    }
}
