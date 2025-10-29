namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    public class TicketHistoryUpdateRequestDTO
    {
        public string ChangeDescription { get; set; }
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
        public string TicketName { get; set; }
    }
}
