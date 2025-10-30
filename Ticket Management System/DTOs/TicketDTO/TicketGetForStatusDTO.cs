namespace Ticket_Management_System.DTOs.TicketDTO
{
    public class TicketGetForStatusDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? SubmittedAt { get; set; }
    }
}
