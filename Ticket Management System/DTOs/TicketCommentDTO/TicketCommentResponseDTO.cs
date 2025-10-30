namespace Ticket_Management_System.DTOs.TicketCommentDTO
{
    public class TicketCommentResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;
        public string AuthorName { get; set; }
        public string TicketName { get; set; }
    }
}
