using Ticket_Management_System.Models;
using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the created ticket.
        /// </summary>
        [RequiredField("Title is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the created ticket.
        /// </summary>
        [RequiredField("Description is required.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the ticket was submitted.
        /// </summary>
        [RequiredField("SubmittedAt is required.")]
        public DateTimeOffset? SubmittedAt { get; set; }

        /// <summary>
        /// Gets or sets the name of the support agent assigned to the ticket.
        /// If no agent is assigned during creation, this may be null.
        /// </summary>
        [RequiredField("SupportAgentName is required.")]
        public string SupportAgentName { get; set; }
    }
}
