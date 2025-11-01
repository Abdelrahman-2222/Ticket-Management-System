using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.DepartmentDTO
{
    /// <summary>
    /// Data Transfer Object representing the response containing an employee's department ID.
    /// </summary>
    public class DepartmentIDEmployeeResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the department.
        /// </summary>
        [RequiredField("Department Id is required.")]
        public int Id { get; set; }
    }
}
