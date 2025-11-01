using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    /// <summary>
    /// Represents the data required to update an existing ticket.
    /// </summary>
    public class TicketUpdateRequestDTO
    {
        /// <summary>
        /// Gets or sets the updated title of the ticket.
        /// If not provided, the existing title will remain unchanged.
        /// </summary>
        [RequiredField("Title is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the updated description of the ticket.
        /// If not provided, the existing description will remain unchanged.
        /// </summary>
        [RequiredField("Description is required.")]
        public string Description { get; set; }
    }
}
