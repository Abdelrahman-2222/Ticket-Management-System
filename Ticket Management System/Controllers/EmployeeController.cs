using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Services;

namespace Ticket_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponseDTO>> CreateEmployee(EmployeeRequestDTO employeeRequestDTO)
        {
            var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeRequestDTO);
            if (createdEmployee == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee.");
            }
            return CreatedAtAction(nameof(CreateEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

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
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeResponseDTO>> UpdateEmployee(int id, EmployeeRequestDTO employeeRequestDTO)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeRequestDTO);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

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
