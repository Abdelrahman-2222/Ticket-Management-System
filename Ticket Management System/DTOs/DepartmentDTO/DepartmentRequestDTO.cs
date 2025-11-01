using System.ComponentModel.DataAnnotations;

namespace Ticket_Management_System.DTOs.DepartmentDTO
{
    /// <summary>
    /// Data Transfer Object for creating or updating a department.
    /// </summary>
    public class DepartmentRequestDTO
    {
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
