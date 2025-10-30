using System.ComponentModel.DataAnnotations;

namespace Ticket_Management_System.DTOs.DepartmentDTO
{
    public class DepartmentRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
