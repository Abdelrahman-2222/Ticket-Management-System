using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.DTOs.SupportAgentDTO
{
    public class SupportAgentGetByIdResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public ICollection<TicketInsertResponseDTO> Tickets { get; set; }
    }
}
