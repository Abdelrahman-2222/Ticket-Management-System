using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.EmployeeDTO
{
    /// <summary>
    /// Represents the request data transfer object for creating or updating an employee.
    /// </summary>
    public class EmployeeRequestDTO
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        [RequiredField("Employee name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [RequiredField("Employee email is required.")]

        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the department associated with the employee.
        /// </summary>
        public DepartmentResponseDTO Department { get; set; }
    }
}
