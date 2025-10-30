using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;

namespace Ticket_Management_System.Contracts
{
    public interface IDepartmentService
    {
        Task<DepartmentResponseDTO> CreateDepartmentAsync(DepartmentRequestDTO departmentRequestDTO);
        Task<DepartmentResponseDTO> GetDepartmentByIdAsync(int id);
        Task<List<DepartmentResponseDTO>> GetAllDepartmentsAsync();
        Task<DepartmentResponseDTO> UpdateDepartmentAsync(int id, DepartmentRequestDTO departmentRequestDTO);
        Task<string> DeleteDepartmentAsync(int id);
    }
}
