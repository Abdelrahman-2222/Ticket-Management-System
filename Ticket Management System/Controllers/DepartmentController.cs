using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.Services;

namespace Ticket_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentResponseDTO>> CreateDepartment(DepartmentRequestDTO departmentRequestDTO)
        {
            var createdDepartment = await _departmentService.CreateDepartmentAsync(departmentRequestDTO);
            if (createdDepartment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating department.");
            }
            return CreatedAtAction(nameof(CreateDepartment), new { id = createdDepartment.Id }, createdDepartment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResponseDTO>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentResponseDTO>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            if (departments == null || !departments.Any())
            {
                return NotFound();
            }
            return Ok(departments);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentResponseDTO>> UpdateDepartment(int id, DepartmentRequestDTO departmentRequestDTO)
        {
            var updatedDepartment = await _departmentService.UpdateDepartmentAsync(id, departmentRequestDTO);
            if (updatedDepartment == null)
            {
                return NotFound();
            }
            return Ok(updatedDepartment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
