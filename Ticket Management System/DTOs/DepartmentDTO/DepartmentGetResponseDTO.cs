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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public string Name { get; set; }
    }
}
