using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    /// <summary>
    /// Represents the data required to create a new support ticket.
    /// </summary>
    public sealed class TicketInsertRequestDTO
    {
        /// <summary>
        /// Gets or sets the title of the ticket.
        /// This field is required and describes the main issue.
        /// </summary>
        [Required]
        public required string Title { get; init; }

        /// <summary>
        /// Gets or sets the detailed description of the ticket issue.
        /// This field is required.
        /// </summary>
        [Required]
        public required string Description { get; init; }

        /// <summary>
        /// Gets or sets the identifier of the employee submitting the ticket.
        /// </summary>
        public int EmployeeId { get; init; }

        /// <summary>
        /// Gets or sets the identifier of the support agent assigned to the ticket.
        /// This is optional and may be assigned later.
        /// </summary>
        public int? SupportAgentId { get; init; }

        /// <summary>
        /// Gets or sets the identifier of the ticket category.
        /// Defines the category this ticket belongs to. This field is required.
        /// </summary>
        [Required]
        public required int TicketCategoryId { get; init; }

        /// <summary>
        /// Gets or sets the identifier of the ticket status.
        /// Represents the current state of the ticket in the workflow.
        /// </summary>
        public int TicketStatusId { get; init; }

        /// <summary>
        /// Gets or sets the identifier of the ticket priority level.
        /// Determines the urgency level of the ticket.
        /// </summary>
        public int TicketPriorityId { get; init; }

        /// <summary>
        /// Gets or sets a list of comments associated with the ticket during creation.
        /// This can be empty.
        /// </summary>
        public List<TicketCommentInsertRequestDTO> Comments { get; init; } = [];
    }
}
