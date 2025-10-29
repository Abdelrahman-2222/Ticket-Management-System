using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a support agent responsible for handling and resolving tickets.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="IBaseId"/> and <see cref="IBaseName"/> to provide common identity and naming.
    /// Agents can be assigned to multiple <see cref="Ticket"/> instances.
    /// </remarks>
    public class SupportAgent : IBaseId, IBaseName
    {
        /// <summary>
        /// Gets or sets the unique identifier for the support agent.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the support agent name.
        /// </summary>
        /// <remarks>
        /// The length is constrained by <see cref="AnnotationSettings.NameMinLength"/> and
        /// <see cref="AnnotationSettings.NameMaxLength"/>.
        /// </remarks>
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; }

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
