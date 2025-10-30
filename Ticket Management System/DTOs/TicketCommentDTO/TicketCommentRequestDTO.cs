namespace Ticket_Management_System.DTOs.TicketCommentDTO
{
    public class TicketCommentRequestDTO
    {
        public int TicketId { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
    }
}
