using Microsoft.Identity.Client;
using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Ticket Status Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ticket status.
        /// </summary>
        [RequiredField("Ticket Status Name is required.")]
        public string TicketStatusName { get; set; }
    }
}
