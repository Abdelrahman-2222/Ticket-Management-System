namespace Ticket_Management_System.DTOs.TicketPriorityDTO
{
    /// <summary>
    /// Represents the response data for a ticket priority.
    /// </summary>
    public class TicketPriorityResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ticket priority.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ticket priority.
        /// </summary>
        public string Name { get; set; }

    }
}
