using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.DTOs.TicketCategoryDTO
{
    /// <summary>
    /// Represents a data transfer object (DTO) used to return detailed information 
    /// about a ticket category, including its associated tickets.
    /// </summary>
    public class TicketCategoryResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ticket category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ticket category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets that belong to this category.
        /// </summary>
        public ICollection<TicketInsertResponseDTO> Tickets { get; set; }
    }
}
