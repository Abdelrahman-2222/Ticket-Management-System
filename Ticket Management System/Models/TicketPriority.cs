using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a priority level applied to support tickets (e.g., Low, Medium, High, Critical).
    /// </summary>
    /// <remarks>
    /// Implements <see cref="EntityBase"/> and <see cref="NamedEntityBase"/> to provide common identity and naming.
    /// Used by <see cref="Ticket"/> to indicate urgency and influence handling order.
    /// </remarks>
    public class TicketPriority : NamedEntityBase
    {
        /// <summary>
        /// Gets or sets the collection of tickets that are assigned this priority.
        /// </summary>
        /// <remarks>
        /// Navigation property representing the one-to-many relationship between priority and tickets.
        /// </remarks>
        public ICollection<Ticket> Tickets { get; set; }
    }
}
