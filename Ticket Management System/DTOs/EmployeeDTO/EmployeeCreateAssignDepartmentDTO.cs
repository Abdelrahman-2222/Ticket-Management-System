using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.EmployeeDTO
{
    /// <summary>
    /// Data Transfer Object for creating an employee and assigning a department.
    /// </summary>
    public class EmployeeCreateAssignDepartmentDTO
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
        /// Gets or sets the department assigned to the employee.
        /// </summary>
        public DepartmentIDEmployeeResponseDTO Department { get; set; }
    }
}
