using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    public class TicketHistoryGetForTickets
    {
        public ICollection<TicketHistoryDTO> HistoryLogs { get; set; }
    }
    public class TicketHistoryDTO
    {
        public int Id { get; set; }
        public string ChangeDescription { get; set; }
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    }
}
