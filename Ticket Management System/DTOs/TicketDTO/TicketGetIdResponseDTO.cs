using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketCategoryDTO;
using Ticket_Management_System.DTOs.TicketHistoryDTO;
using Ticket_Management_System.DTOs.TicketPriorityDTO;
using Ticket_Management_System.DTOs.TicketStatusDTO;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    /// <summary>
    /// Represents the complete ticket data returned when retrieving a ticket by its identifier.
    /// Includes detailed information such as employee, support agent, priority, status, category, and history.
    /// </summary>
    public class TicketGetIdResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ticket.
        /// </summary>
        [RequiredField("Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the ticket.
        /// </summary>
        [RequiredField("Title is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the ticket issue.
        /// </summary>
        [RequiredField("Description is required.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was resolved, if applicable.
        /// </summary>
        [RequiredField("ResolvedAt is required.")]
        public DateTime? ResolvedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was submitted.
        /// </summary>
        [RequiredField("SubmittedAt is required.")]
        public DateTimeOffset? SubmittedAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Gets or sets information about the support agent assigned to the ticket.
        /// </summary>
        public SupportAgentResponseDTO SupportAgentName { get; set; }

        /// <summary>
        /// Gets or sets information about the employee who submitted the ticket.
        /// </summary>
        public EmployeeResponseDTO EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the status assigned to the ticket.
        /// </summary>
        public TicketStatusResponseDTO TicketStatus { get; set; }

        /// <summary>
        /// Gets or sets the priority assigned to the ticket.
        /// </summary>
        public TicketPriorityResponseDTO TicketPriority { get; set; }

        /// <summary>
        /// Gets or sets the category assigned to the ticket.
        /// </summary>
        public TicketCategoryResponseDTO TicketCategory { get; set; }

        /// <summary>
        /// Gets or sets the history log entries associated with the ticket.
        /// </summary>
        public TicketHistoryGetForTickets TicketHistory { get; set; }
    }
}
