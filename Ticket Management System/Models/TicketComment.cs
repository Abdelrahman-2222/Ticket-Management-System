using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a comment left on a support <see cref="Ticket"/>.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="IBaseId"/> and belongs to a single <see cref="Ticket"/>.
    /// Used to capture discussion and updates related to the ticket.
    /// </remarks>
    public class TicketComment : IBaseId
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ticket comment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the textual content of the comment.
        /// </summary>
        /// <remarks>
        /// Constrained by <see cref="AnnotationSettings.ContentMaxLength"/>.
        /// </remarks>
        [MaxLength(AnnotationSettings.ContentMaxLength)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the comment was created.
        /// </summary>
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Gets or sets the display name of the author who authored the comment.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the associated <see cref="Ticket"/>.
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        /// Gets or sets the ticket this comment belongs to.
        /// </summary>
        /// <remarks>
        /// Navigation property (many-to-one).
        /// </remarks>
        public Ticket Ticket { get; set; }
    }
}
