using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.TicketCategoryDTO
{
    /// <summary>
    /// Represents a data transfer object (DTO) used to create or update a ticket category.
    /// </summary>
    public class TicketCategoryRequestDTO
    {
        /// <summary>
        /// Gets or sets the name of the ticket category.
        /// </summary>
        /// <remarks>
        /// This field is required and must not be empty.
        /// </remarks>
        [RequiredField("Name is required.")]
        public string Name { get; set; }
    }
}
