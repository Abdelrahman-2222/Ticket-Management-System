using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Services;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Controller for managing employees and their department assignments.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeService">The employee service.</param>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Creates a new employee and assigns them to a department.
        /// </summary>
        /// <param name="employeeRequestDTO">The employee creation and department assignment data.</param>
        /// <returns>The created employee with department details.</returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeResponseDTO>> CreateEmployee(EmployeeCreateAssignDepartmentDTO employeeRequestDTO)
        {
            var validationResult = ValidateModel(employeeRequestDTO);
            if (validationResult != null) return validationResult;
            var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeRequestDTO);
            if (createdEmployee == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee.");
            }
            return CreatedAtAction(nameof(CreateEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        /// <summary>
        /// Retrieves an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <returns>The employee with department details if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponseDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Retrieves all employees with their department details.
        /// </summary>
        /// <returns>A list of all employees and their departments.</returns>
        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponseDTO>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            if (employees == null || !employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }

        /// <summary>
        /// Updates the details of an existing employee.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to update.</param>
        /// <param name="employeeRequestDTO">The updated employee data.</param>
        /// <returns>The updated employee with department details if found; otherwise, NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeResponseDTO>> UpdateEmployee(int id, EmployeeUpdateRequest employeeRequestDTO)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeRequestDTO);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        /// <summary>
        /// Deletes an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to delete.</param>
        /// <returns>A message indicating the result of the deletion operation.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
