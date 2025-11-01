using System.Threading.Tasks;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Contracts
{
    /// <summary>
    /// Provides methods for managing employees and their department assignments.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Creates a new employee and assigns them to a department.
        /// </summary>
        /// <param name="employeeRequestDTO">The employee creation and department assignment data.</param>
        /// <returns>The created employee with department details.</returns>
        Task<EmployeeDeptResponeDTO> CreateEmployeeAsync(EmployeeCreateAssignDepartmentDTO employeeRequestDTO);

        /// <summary>
        /// Retrieves an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <returns>The employee with department details if found; otherwise, null.</returns>
        Task<EmployeeDeptResponeDTO> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Retrieves all employees with their department details.
        /// </summary>
        /// <returns>A list of all employees and their departments.</returns>
        Task<List<EmployeeDeptResponeDTO>> GetAllEmployeesAsync();

        /// <summary>
        /// Updates the details of an existing employee.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to update.</param>
        /// <param name="employeeRequestDTO">The updated employee data.</param>
        /// <returns>The updated employee with department details.</returns>
        Task<EmployeeDeptResponeDTO> UpdateEmployeeAsync(int id, EmployeeUpdateRequest employeeRequestDTO);

        /// <summary>
        /// Deletes an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to delete.</param>
        /// <returns>A message indicating the result of the deletion operation.</returns>
        Task<string> DeleteEmployeeAsync(int id);
    }
}
