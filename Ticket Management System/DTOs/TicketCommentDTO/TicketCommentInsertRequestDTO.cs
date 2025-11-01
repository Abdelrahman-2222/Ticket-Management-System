using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.TicketCommentDTO
{
    /// <summary>
    /// Represents the data required to insert a new ticket comment.
    /// </summary>
    public class TicketCommentInsertRequestDTO
    {
        /// <summary>
        /// Gets or sets the content of the comment.
        /// </summary>
        [RequiredField("Content is required.")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the name of the author who wrote the comment.
        /// </summary>
        [RequiredField("AuthorName is required.")]
        public string AuthorName { get; set; }
    }
}
