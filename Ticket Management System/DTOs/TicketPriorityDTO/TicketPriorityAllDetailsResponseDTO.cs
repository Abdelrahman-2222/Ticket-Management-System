using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.TicketPriorityDTO
{
    public class TicketPriorityAllDetailsResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ticket priority.
        /// </summary>
        [RequiredField("Ticket Priority Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ticket priority.
        /// </summary>
        [RequiredField("Ticket Priority Name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets associated with this priority.
        /// </summary>
        public List<TicketGetForStatusDTO> Tickets { get; set; } = new();
    }
}
