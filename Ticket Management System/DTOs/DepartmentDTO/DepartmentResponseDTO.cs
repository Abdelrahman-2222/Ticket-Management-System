using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.DepartmentDTO
{
    public class DepartmentResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeGetResponseDTO> Employees { get; set; }
    }
}
