using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;
using Ticket_Management_System.Services.SharedServiceValidations;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Provides services for managing departments, including CRUD operations.
    /// </summary>
    public class DepartmentService :  EnsureValid,IDepartmentService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class.
        /// </summary>
        /// <param name="context">The database context to use for department operations.</param>
        public DepartmentService(TicketContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves all changes made in this context to the database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="departmentRequestDTO">The department data to create.</param>
        /// <returns>The created department details.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="departmentRequestDTO"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the department name is null or whitespace.</exception>
        public async Task<DepartmentResponseDTO> CreateDepartmentAsync(DepartmentRequestDTO departmentRequestDTO)
        {
            EnsureValidDTOOnly<DepartmentRequestDTO>(departmentRequestDTO);
            var newDepartment = new Department
            {
                Name = departmentRequestDTO.Name.Trim()
            };

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return new DepartmentResponseDTO
            {
                Id = newDepartment.Id,
                Name = newDepartment.Name,
            };
        }

        /// <summary>
        /// Gets a department by its unique identifier.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <returns>The department details if found; otherwise, null.</returns>
        public async Task<DepartmentResponseDTO> GetDepartmentByIdAsync(int id)
        {
            EnsureValidIDOnly<DepartmentResponseDTO>(id);
            var department = await _context.Departments
                .Where(d => d.Id == id)
                .Select(d => new DepartmentResponseDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Employees = d.Employees.Select(em => new EmployeeGetResponseDTO
                    {
                        Id = em.Id,
                        Name = em.Name,
                        Email = em.Email
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return department;
        }

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns>A list of all departments.</returns>
        public async Task<List<DepartmentResponseDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments
                .Select(d => new DepartmentResponseDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Employees = d.Employees.Select(em => new EmployeeGetResponseDTO
                    {
                        Id = em.Id,
                        Name = em.Name,
                        Email = em.Email
                    }).ToList()
                }).ToListAsync();

            return departments;
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <param name="departmentRequestDTO">The updated department data.</param>
        /// <returns>The updated department details.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the department with the specified ID is not found.</exception>
        public async Task<DepartmentResponseDTO> UpdateDepartmentAsync(int id, DepartmentRequestDTO departmentRequestDTO)
        {
            EnsureValidDTOWithID<DepartmentRequestDTO>(departmentRequestDTO, id);
            var department = await _context.Departments
                             .Include(d => d.Employees)
                             .FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }
            department.Name = departmentRequestDTO.Name;
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            var responseDTO = new DepartmentResponseDTO
            {
                Id = department.Id,
                Name = department.Name,
                Employees = department.Employees.Select(em => new EmployeeGetResponseDTO
                {
                    Id = em.Id,
                    Name = em.Name,
                    Email = em.Email
                }).ToList()
            };
            return responseDTO;
        }

        /// <summary>
        /// Deletes a department by its unique identifier.
        /// </summary>
        /// <param name="id">The department identifier.</param>
        /// <returns>A message indicating the result of the delete operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the department with the specified ID is not found.</exception>
        public async Task<string> DeleteDepartmentAsync(int id)
        {
            EnsureValidIDOnly<string>(id);
            var departmentTobeDeleted = await _context.Departments.FindAsync(id);
            if (departmentTobeDeleted == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }

            _context.Departments.Remove(departmentTobeDeleted);
            await _context.SaveChangesAsync();

            return $"Department with ID {id} deleted successfully.";
        }
    }
}
