/*
Plan:
- Add XML documentation to the TicketCategory class and its properties.
- Provide summaries and remarks consistent with other models in the project.
- Reference AnnotationSettings for Name constraints and note navigation property semantics.
- Do not change any signatures or behavior.
*/

using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a category used to classify support tickets (e.g., Hardware, Software, Network).
    /// </summary>
    /// <remarks>
    /// Implements <see cref="EntityBase"/> and <see cref="NamedEntityBase"/> to provide common identity and naming.
    /// Used by <see cref="Ticket"/> to group and filter issues by type.
    /// </remarks>
    public class TicketCategory : NamedEntityBase
    {
        /// <summary>
        /// Gets or sets the collection of tickets assigned to this category.
        /// </summary>
        /// <remarks>
        /// Navigation property representing the one-to-many relationship between category and tickets.
        /// </remarks>
        public ICollection<Ticket> Tickets { get; set; }
    }
}
