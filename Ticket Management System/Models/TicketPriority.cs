using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a priority level applied to support tickets (e.g., Low, Medium, High, Critical).
    /// </summary>
    /// <remarks>
    /// Implements <see cref="IBaseId"/> and <see cref="IBaseName"/> to provide common identity and naming.
    /// Used by <see cref="Ticket"/> to indicate urgency and influence handling order.
    /// </remarks>
    public class TicketPriority : IBaseId, IBaseName
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ticket priority.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the priority.
        /// </summary>
        /// <remarks>
        /// Constrained by <see cref="AnnotationSettings.NameMinLength"/> and <see cref="AnnotationSettings.NameMaxLength"/>.
        /// </remarks>
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets that are assigned this priority.
        /// </summary>
        /// <remarks>
        /// Navigation property representing the one-to-many relationship between priority and tickets.
        /// </remarks>
        public ICollection<Ticket> Tickets { get; set; }
    }
}
