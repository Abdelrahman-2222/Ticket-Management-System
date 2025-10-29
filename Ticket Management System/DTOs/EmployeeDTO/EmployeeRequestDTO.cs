using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.DTOs.DepartmentDTO;

namespace Ticket_Management_System.DTOs.EmployeeDTO
{
    public class EmployeeRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public DepartmentResponseDTO Department { get; set; }
    }
}
