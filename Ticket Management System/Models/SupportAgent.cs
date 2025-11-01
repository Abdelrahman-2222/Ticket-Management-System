using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a support agent responsible for handling and resolving tickets.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="EntityBase"/> and <see cref="NamedEntityBase"/> to provide common identity and naming.
    /// Agents can be assigned to multiple <see cref="Ticket"/> instances.
    /// </remarks>
    public class SupportAgent : NamedEntityBase
    {
        /// <summary>
        /// Gets or sets the primary area of expertise for the agent (e.g., Networking, Hardware, Software).
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets assigned to this agent.
        /// </summary>
        /// <remarks>
        /// Navigation property representing the one-to-many relationship between support agent and tickets.
        /// </remarks>
        public ICollection<Ticket> Tickets { get; set; }
    }
}
