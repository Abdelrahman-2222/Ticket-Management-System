using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.EmployeeDTO
{
    /// <summary>
    /// Represents the response data transfer object for retrieving employee information along with department details.
    /// </summary>
    public class EmployeeDeptResponeDTO
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
        /// Gets or sets the department information associated with the employee.
        /// </summary>
        public DepartmentGetResponseDTO Department { get; set; }
    }
}
