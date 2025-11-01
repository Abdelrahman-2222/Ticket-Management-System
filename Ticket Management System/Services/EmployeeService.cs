using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.Models;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Provides services for managing employees, including creation, retrieval, update, and deletion.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="context">The database context to use for employee operations.</param>
        public EmployeeService(TicketContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Persists all changes made in this context to the database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a new employee and assigns them to a department.
        /// </summary>
        /// <param name="employeeRequestDTO">The employee creation request DTO.</param>
        /// <returns>The created employee with department information.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="employeeRequestDTO"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if required fields are missing.</exception>
        public async Task<EmployeeDeptResponeDTO> CreateEmployeeAsync(EmployeeCreateAssignDepartmentDTO employeeRequestDTO)
        {
            var result = GenericValidator.Validate(employeeRequestDTO);
            if (!result.IsValid)
                throw new ArgumentException(result.ErrorMessage);
            var newEmployee = new Employee
            {
                Name = employeeRequestDTO.Name.Trim(),
                Email = employeeRequestDTO.Email.Trim(),
                DepartmentId = employeeRequestDTO.Department.Id,
            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return new EmployeeDeptResponeDTO
            {
                Id = newEmployee.Id,
                Name = newEmployee.Name,
                Email = newEmployee.Email,
                Department = new DepartmentGetResponseDTO
                {
                    Id = newEmployee.DepartmentId,
                    Name = newEmployee.DepartmentId != 0 ? (await _context.Departments.FindAsync(newEmployee.DepartmentId))?.Name ?? string.Empty : string.Empty
                }
            };
        }

        /// <summary>
        /// Retrieves an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The employee's unique identifier.</param>
        /// <returns>The employee with department information, or null if not found.</returns>
        public async Task<EmployeeDeptResponeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Select(E => new EmployeeDeptResponeDTO
                {
                    Id = E.Id,
                    Name = E.Name,
                    Email = E.Email,
                    Department = new DepartmentGetResponseDTO
                    {
                        Id = E.DepartmentId,
                        Name = E.Department != null ? E.Department.Name : string.Empty
                    }
                })
                .SingleOrDefaultAsync(EID => EID.Id == id);

            return employee;
        }

        /// <summary>
        /// Retrieves all employees with their department information.
        /// </summary>
        /// <returns>A list of employees with department details.</returns>
        public async Task<List<EmployeeDeptResponeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Select(E => new EmployeeDeptResponeDTO
                {
                    Id = E.Id,
                    Name = E.Name,
                    Email = E.Email,
                    Department = new DepartmentGetResponseDTO
                    {
                        Id = E.DepartmentId,
                        Name = E.Department != null ? E.Department.Name : string.Empty
                    }
                }).ToListAsync();

            return employees;
        }

        /// <summary>
        /// Updates an existing employee's information.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to update.</param>
        /// <param name="employeeRequestDTO">The updated employee data.</param>
        /// <returns>The updated employee with department information.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the employee is not found.</exception>
        public async Task<EmployeeDeptResponeDTO> UpdateEmployeeAsync(int id, EmployeeUpdateRequest employeeRequestDTO)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            employee.Name = employeeRequestDTO.Name;
            employee.Email = employeeRequestDTO.Email;
            await _context.SaveChangesAsync();
            var responseDTO = await _context.Employees
                .Select(e => new EmployeeDeptResponeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Department = new DepartmentGetResponseDTO
                    {
                        Id = e.Department.Id,
                        Name = e.Department.Name
                    }
                })
                .SingleOrDefaultAsync(e => e.Id == id);
            return responseDTO;
        }

        /// <summary>
        /// Deletes an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to delete.</param>
        /// <returns>A message indicating successful deletion.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the employee is not found.</exception>
        public async Task<string> DeleteEmployeeAsync(int id)
        {
            var employeeTobeDeleted = await _context.Employees.FindAsync(id);
            if (employeeTobeDeleted == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }

            _context.Employees.Remove(employeeTobeDeleted);
            await _context.SaveChangesAsync();

            return $"Employee with ID {id} deleted successfully.";
        }
    }
}
