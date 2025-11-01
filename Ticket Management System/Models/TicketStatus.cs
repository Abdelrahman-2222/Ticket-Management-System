using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents the current lifecycle state of a support ticket (e.g., Open, In Progress, Resolved, Closed).
    /// </summary>
    /// <remarks>
    /// Implements <see cref="EntityBase"/> and <see cref="NamedEntityBase"/> to provide common identity and naming.
    /// Used by <see cref="Ticket"/> to track workflow state.
    /// </remarks>
    public class TicketStatus : NamedEntityBase
    {
        /// <summary>
        /// Gets or sets the collection of tickets that currently have this status.
        /// </summary>
        /// <remarks>
        /// Navigation property representing the one-to-many relationship between status and tickets.
        /// </remarks>
        public ICollection<Ticket> Tickets { get; set; }
    }
}
