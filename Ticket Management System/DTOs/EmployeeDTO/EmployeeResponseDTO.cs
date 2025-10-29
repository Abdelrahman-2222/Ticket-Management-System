using Ticket_Management_System.DTOs.DepartmentDTO;

namespace Ticket_Management_System.DTOs.EmployeeDTO
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartmentResponseDTO Department { get; set; }
    }
}
