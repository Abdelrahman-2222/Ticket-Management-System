using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketCategoryDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.DTOs.TicketPriorityDTO;
using Ticket_Management_System.DTOs.TicketStatusDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly TicketContext _context;
        public EmployeeService(TicketContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        public async Task<EmployeeResponseDTO> CreateEmployeeAsync(EmployeeRequestDTO employeeRequestDTO)
        {
            if (employeeRequestDTO == null)
                throw new ArgumentNullException(nameof(employeeRequestDTO));

            if (string.IsNullOrWhiteSpace(employeeRequestDTO.Name))
                throw new ArgumentException("Name is required.", nameof(employeeRequestDTO.Name));

            if (string.IsNullOrWhiteSpace(employeeRequestDTO.Email))
                throw new ArgumentException("Email is required.", nameof(employeeRequestDTO.Email));


            var newEmployee = new Employee
            {
                Name = employeeRequestDTO.Name.Trim(),
                Email = employeeRequestDTO.Email.Trim(),
                DepartmentId = employeeRequestDTO.Department.Id,
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();


            return new EmployeeResponseDTO
            {
                Id = newEmployee.Id,
                Name = newEmployee.Name,
                Email = newEmployee.Email,
                Department = new DepartmentResponseDTO
                {
                     Id = newEmployee.DepartmentId,
                     Name = _context.Departments.SingleOrDefaultAsync(d => d.Id == newEmployee.DepartmentId).Result.Name
                }
            };
        }

        public async Task<EmployeeResponseDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Select(E => new EmployeeResponseDTO
                {
                    Id = E.Id,
                    Name = E.Name,
                    Email = E.Email,
                    Department = new DepartmentResponseDTO
                    {
                        Id = E.DepartmentId,
                        Name = _context.Departments
                            .Where(D => D.Id == E.DepartmentId)
                            .Select(D => D.Name)
                            .FirstOrDefault()
                    }
                })
                .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<List<EmployeeResponseDTO>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Select(E => new EmployeeResponseDTO
                {
                    Id = E.Id,
                    Name = E.Name,
                    Email = E.Email,
                    Department = new DepartmentResponseDTO
                    {
                        Id = E.DepartmentId,
                        Name = _context.Departments
                            .Where(D => D.Id == E.DepartmentId)
                            .Select(D => D.Name)
                            .FirstOrDefault()
                    }
                }).ToListAsync();

            return employees;
        }

        public async Task<EmployeeResponseDTO> UpdateEmployeeAsync(int id, EmployeeRequestDTO employeeRequestDTO)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            employee.Name = employeeRequestDTO.Name;
            employee.Email = employeeRequestDTO.Email;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            var responseDTO = new EmployeeResponseDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = new DepartmentResponseDTO
                {
                    Id = employee.DepartmentId,
                    Name = _context.Departments
                            .Where(D => D.Id == employee.DepartmentId)
                            .Select(D => D.Name)
                            .FirstOrDefault()
                }
            };
            return responseDTO;
        }

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
