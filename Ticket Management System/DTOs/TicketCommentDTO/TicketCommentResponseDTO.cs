﻿namespace Ticket_Management_System.DTOs.TicketCommentDTO
{
    /// <summary>
    /// Represents the data returned for a ticket comment.
    /// </summary>
    public class TicketCommentResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the comment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the content of the comment.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was created.
        /// </summary>
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Gets or sets the name of the author who wrote the comment.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the name of the ticket to which the comment belongs.
        /// </summary>
        public string TicketName { get; set; }
    }
}
