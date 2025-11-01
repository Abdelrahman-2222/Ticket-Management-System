using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a support ticket submitted by an <see cref="Employee"/> and optionally handled by a <see cref="SupportAgent"/>.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="EntityBase"/> and <see cref="NamedEntityBase"/> and includes relationships to status, priority, and category,
    /// as well as collections of comments and history logs.
    /// </remarks>
    public class Ticket : NamedEntityBase
    {
        /// <summary>
        /// Gets or sets the title of the ticket.
        /// </summary>
        /// <remarks>
        /// Constrained by <see cref="AnnotationSettings.NameMinLength"/> and <see cref="AnnotationSettings.NameMaxLength"/>.
        /// </remarks>
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Title { get; set; }

        [NotMapped]
        public override string Name
        {
            get => Title;
            set => Title = value;
        }

        /// <summary>
        /// Gets or sets the detailed description of the reported issue.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the ticket was submitted.
        /// </summary>
        public DateTimeOffset? SubmittedAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Gets or sets the timestamp when the ticket was resolved.
        /// </summary>
        /// <remarks>
        /// Null until the ticket is resolved.
        /// </remarks>
        public DateTime? ResolvedAt { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the <see cref="Models.Employee"/> who submitted the ticket.
        /// </summary>
        public int EmployeeId { get; set; }        

        /// <summary>
        /// Gets or sets the foreign key of the assigned <see cref="Models.SupportAgent"/>, if any.
        /// </summary>
        public int? SupportAgentId { get; set; }     

        /// <summary>
        /// Gets or sets the foreign key of the ticket's current <see cref="Models.TicketStatus"/>.
        /// </summary>
        public int TicketStatusId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the ticket's <see cref="Models.TicketPriority"/>.
        /// </summary>
        public int TicketPriorityId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the ticket's <see cref="Models.TicketCategory"/>.
        /// </summary>
        public int TicketCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the employee who submitted the ticket.
        /// </summary>
        /// <remarks>
        /// Navigation property (many-to-one).
        /// </remarks>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the support agent assigned to handle the ticket.
        /// </summary>
        /// <remarks>
        /// Navigation property (many-to-one). May be null if unassigned.
        /// </remarks>
        public SupportAgent SupportAgent { get; set; }

        /// <summary>
        /// Gets or sets the current status of the ticket.
        /// </summary>
        /// <remarks>
        /// Navigation property (many-to-one).
        /// </remarks>
        public TicketStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the priority of the ticket.
        /// </summary>
        /// <remarks>
        /// Navigation property (many-to-one).
        /// </remarks>
        public TicketPriority Priority { get; set; }

        /// <summary>
        /// Gets or sets the category of the ticket.
        /// </summary>
        /// <remarks>
        /// Navigation property (many-to-one).
        /// </remarks>
        public TicketCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the collection of comments associated with the ticket.
        /// </summary>
        /// <remarks>
        /// Navigation property (one-to-many).
        /// </remarks>
        public ICollection<TicketComment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the collection of history log entries that track changes made to the ticket.
        /// </summary>
        /// <remarks>
        /// Navigation property (one-to-many).
        /// </remarks>
        public ICollection<TicketHistory> HistoryLogs { get; set; }

    }
}
