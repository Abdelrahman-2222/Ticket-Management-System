using System.ComponentModel.DataAnnotations;

namespace Ticket_Management_System.DTOs.TicketPriorityDTO
{
    /// <summary>
    /// Represents the response data for a ticket priority.
    /// </summary>
    public class TicketPriorityRequestDTO
    {
        /// <summary>
        /// Gets or sets the name of the ticket priority.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
