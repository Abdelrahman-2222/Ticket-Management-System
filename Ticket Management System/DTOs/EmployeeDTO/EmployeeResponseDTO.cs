using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.EmployeeDTO
{
    /// <summary>
    /// Represents the response data transfer object for an employee.
    /// </summary>
    public class EmployeeResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        [RequiredField("Employee ID is required.")]

        public int Id { get; set; }

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
