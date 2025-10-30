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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the ticket.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the ticket issue.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was submitted.
        /// </summary>
        public DateTimeOffset? SubmittedAt { get; set; }
    }
}
