namespace Ticket_Management_System.DTOs.TicketDTO
{
    /// <summary>
    /// Represents the response data returned after updating an existing ticket.
    /// </summary>
    public class TicketUpdateResponeDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the updated ticket.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the updated title of the ticket.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the updated description of the ticket.
        /// </summary>
        public string Description { get; set; }
    }
}
