using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.DepartmentDTO
{
    /// <summary>
    /// Represents the response data transfer object for a department.
    /// </summary>
    public class DepartmentResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the department.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of employees associated with the department.
        /// </summary>
        public ICollection<EmployeeGetResponseDTO> Employees { get; set; }
    }
}
