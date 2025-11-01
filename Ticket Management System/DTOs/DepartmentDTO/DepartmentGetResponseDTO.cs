using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.DTOs.DepartmentDTO
{
    /// <summary>
    /// Represents the response data transfer object for retrieving department information.
    /// </summary>
    public class DepartmentGetResponseDTO
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
    }
}
