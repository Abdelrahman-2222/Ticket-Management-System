using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the updated title of the ticket.
        /// </summary>
        [RequiredField("Title is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the updated description of the ticket.
        /// </summary>
        [RequiredField("Description is required.")]
        public string Description { get; set; }
    }
}
