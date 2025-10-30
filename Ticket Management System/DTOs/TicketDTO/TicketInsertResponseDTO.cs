using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    /// <summary>
    /// Represents the response returned after successfully creating a new ticket.
    /// </summary>
    public class TicketInsertResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the created ticket.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the created ticket.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the created ticket.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the ticket was submitted.
        /// </summary>
        public DateTimeOffset? SubmittedAt { get; set; }

        /// <summary>
        /// Gets or sets the name of the support agent assigned to the ticket.
        /// If no agent is assigned during creation, this may be null.
        /// </summary>
        public string SupportAgentName { get; set; }
    }
}
