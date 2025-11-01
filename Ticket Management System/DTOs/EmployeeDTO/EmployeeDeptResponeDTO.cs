using Ticket_Management_System.DTOs.DepartmentDTO;

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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the department information associated with the employee.
        /// </summary>
        public DepartmentGetResponseDTO Department { get; set; }
    }
}
