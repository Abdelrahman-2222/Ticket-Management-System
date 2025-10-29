namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    public class TicketHistoryResponseGetByIdDTO
    {
        public int Id { get; set; }
        public string ChangeDescription { get; set; }
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
        public string TicketName { get; set; }
    }
}
