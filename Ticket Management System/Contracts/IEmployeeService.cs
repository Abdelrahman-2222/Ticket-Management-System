using System.Threading.Tasks;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Contracts

{
    public interface IEmployeeService
    {
        Task<EmployeeResponseDTO> CreateEmployeeAsync(EmployeeRequestDTO employeeRequestDTO);
        Task<EmployeeResponseDTO> GetEmployeeByIdAsync(int id);
        Task<List<EmployeeResponseDTO>> GetAllEmployeesAsync();
        Task<EmployeeResponseDTO> UpdateEmployeeAsync(int id, EmployeeRequestDTO employeeRequestDTO);
        Task<string> DeleteEmployeeAsync(int id);

    }
}
