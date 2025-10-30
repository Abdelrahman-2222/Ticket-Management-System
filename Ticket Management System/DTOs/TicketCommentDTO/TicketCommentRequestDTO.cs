namespace Ticket_Management_System.DTOs.TicketCommentDTO
{
    /// <summary>
    /// Represents the data required to create or update a ticket comment.
    /// </summary>
    public class TicketCommentRequestDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ticket associated with the comment.
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        /// Gets or sets the content of the comment.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the name of the author who wrote the comment.
        /// </summary>
        public string AuthorName { get; set; }
    }
}
