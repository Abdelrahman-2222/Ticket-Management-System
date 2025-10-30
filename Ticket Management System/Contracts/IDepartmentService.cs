using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;

namespace Ticket_Management_System.Contracts
{
    /// <summary>
    /// Provides contract for department-related operations.
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="departmentRequestDTO">The department data to create.</param>
        /// <returns>The created department details.</returns>
        Task<DepartmentResponseDTO> CreateDepartmentAsync(DepartmentRequestDTO departmentRequestDTO);

        /// <summary>
        /// Gets a department by its unique identifier.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <returns>The department details if found; otherwise, null.</returns>
        Task<DepartmentResponseDTO> GetDepartmentByIdAsync(int id);

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns>A list of all departments.</returns>
        Task<List<DepartmentResponseDTO>> GetAllDepartmentsAsync();

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <param name="departmentRequestDTO">The updated department data.</param>
        /// <returns>The updated department details.</returns>
        Task<DepartmentResponseDTO> UpdateDepartmentAsync(int id, DepartmentRequestDTO departmentRequestDTO);

        /// <summary>
        /// Deletes a department by its unique identifier.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <returns>A message indicating the result of the delete operation.</returns>
        Task<string> DeleteDepartmentAsync(int id);
    }
}
