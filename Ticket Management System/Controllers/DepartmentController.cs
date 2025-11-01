using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.Models;
using Ticket_Management_System.Services;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Controller for managing department-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentController"/> class.
        /// </summary>
        /// <param name="departmentService">The department service.</param>
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="departmentRequestDTO">The department data to create.</param>
        /// <returns>The created department details.</returns>
        [HttpPost]
        public async Task<ActionResult<DepartmentResponseDTO>> CreateDepartment(DepartmentRequestDTO departmentRequestDTO)
        {
            var validation = ValidateDTO(departmentRequestDTO);
            if (validation != null) return validation;
            var createdDepartment = await _departmentService.CreateDepartmentAsync(departmentRequestDTO);
            if (createdDepartment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating department.");
            }
            return CreatedAtAction(nameof(CreateDepartment), new { id = createdDepartment.Id }, createdDepartment);
        }

        /// <summary>
        /// Gets a department by its unique identifier.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <returns>The department details if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResponseDTO>> GetDepartmentById(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFoundResponse("Department", id);
            }
            return Ok(department);
        }

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns>A list of all departments.</returns>
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

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <param name="departmentRequestDTO">The updated department data.</param>
        /// <returns>The updated department details if found; otherwise, NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentResponseDTO>> UpdateDepartment(int id, DepartmentRequestDTO departmentRequestDTO)
        {
            var validation = ValidateDTOWithId<DepartmentRequestDTO>(departmentRequestDTO,id);
            if (validation != null) return validation;
            var updatedDepartment = await _departmentService.UpdateDepartmentAsync(id, departmentRequestDTO);
            if (updatedDepartment == null)
            {
                return NotFoundResponse("Department", id);
            }
            return Ok(updatedDepartment);
        }

        /// <summary>
        /// Deletes a department by its unique identifier.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <returns>A message indicating the result of the delete operation if found; otherwise, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteDepartment(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;
            var result = await _departmentService.DeleteDepartmentAsync(id);
            if (result == null)
            {
                return NotFoundResponse("Department", id);
            }
            return Ok(result);
        }
    }
}
