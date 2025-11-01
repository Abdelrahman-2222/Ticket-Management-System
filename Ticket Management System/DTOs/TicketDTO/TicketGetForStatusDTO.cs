using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    /// <summary>
    /// Represents the ticket details returned when filtering tickets by status.
    /// </summary>
    public class TicketGetForStatusDTO
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
        /// Gets or sets a brief description of the ticket issue.
        /// </summary>
        [RequiredField("Description is required.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was submitted.
        /// </summary>
        [RequiredField("DateTimeOffset is required.")]
        public DateTimeOffset? SubmittedAt { get; set; }
    }
}
