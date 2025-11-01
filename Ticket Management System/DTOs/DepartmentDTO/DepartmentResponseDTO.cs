using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.Models;
using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Department Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        [RequiredField("Department Name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of employees associated with the department.
        /// </summary>
        public ICollection<EmployeeGetResponseDTO> Employees { get; set; }
    }
}
