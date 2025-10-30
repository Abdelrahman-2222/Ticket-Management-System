using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly TicketContext _context;
        public DepartmentService(TicketContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        public async Task<DepartmentResponseDTO> CreateDepartmentAsync(DepartmentRequestDTO departmentRequestDTO)
        {
            if (departmentRequestDTO == null)
                throw new ArgumentNullException(nameof(departmentRequestDTO));

            if (string.IsNullOrWhiteSpace(departmentRequestDTO.Name))
                throw new ArgumentException("Name is required.", nameof(departmentRequestDTO.Name));


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

        public async Task<DepartmentResponseDTO> GetDepartmentByIdAsync(int id)
        {
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

        public async Task<DepartmentResponseDTO> UpdateDepartmentAsync(int id, DepartmentRequestDTO departmentRequestDTO)
        {
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

        public async Task<string> DeleteDepartmentAsync(int id)
        {
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
