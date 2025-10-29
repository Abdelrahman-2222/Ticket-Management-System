using System.ComponentModel.DataAnnotations;

namespace Ticket_Management_System.DTOs.TicketCategoryDTO
{
    public class TicketCategoryRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
