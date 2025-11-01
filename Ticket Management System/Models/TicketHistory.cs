using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a single change log entry for a <see cref="Ticket"/>.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="EntityBase"/> and belongs to a single <see cref="Ticket"/>.
    /// Used to maintain an audit trail of updates made to the ticket over time.
    /// </remarks>
    public class TicketHistory : EntityBase
    {
        /// <summary>
        /// Gets or sets a human-readable description of what changed on the ticket.
        /// </summary>
        /// <remarks>
        /// Examples: "Status changed from Open to In Progress", "Priority updated to High", "Assigned to John Doe".
        /// </remarks>
        public string ChangeDescription { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the change was recorded.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Gets or sets the foreign key of the associated <see cref="Ticket"/>.
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        /// Gets or sets the ticket this history entry belongs to.
        /// </summary>
        /// <remarks>
        /// Navigation property (many-to-one).
        /// </remarks>
        public Ticket Ticket { get; set; }
    }
}
