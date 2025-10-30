namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    public class TicketHistoryInsertRequestDTO
    {
        public string ChangeDescription { get; set; }
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
        public int TicketId { get; set; }
    }
}
