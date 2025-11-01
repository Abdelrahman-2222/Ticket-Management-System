using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Ticket Priority Name is required.")]
        public string Name { get; set; }
    }
}
