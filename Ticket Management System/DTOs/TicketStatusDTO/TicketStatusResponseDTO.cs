using Microsoft.Identity.Client;

namespace Ticket_Management_System.DTOs.TicketStatusDTO
{
    /// <summary>
    /// Represents the response data transfer object for a ticket status.
    /// </summary>
    public class TicketStatusResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ticket status.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ticket status.
        /// </summary>
        public string TicketStatusName { get; set; }
    }
}
