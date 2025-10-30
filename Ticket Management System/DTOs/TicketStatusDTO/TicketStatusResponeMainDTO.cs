using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.TicketStatusDTO
{
    /// <summary>
    /// Represents the main response DTO for a ticket status, including its details and associated tickets.
    /// </summary>
    public class TicketStatusResponeMainDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ticket status.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ticket status.
        /// </summary>
        public string TicketStatusName { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets associated with this status.
        /// </summary>
        public ICollection<TicketGetForStatusDTO> TicketDTO { get; set; }
    }
}
