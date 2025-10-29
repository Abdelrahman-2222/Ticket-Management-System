using Ticket_Management_System.DTOs.TicketCategoryDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketCategoryService
    {
        Task<List<TicketCategoryResponseDTO>> GetAllTicketCategoryAsync();
        Task<TicketCategoryResponseDTO> GetTicketCategoryByIdAsync(int id);
        Task<TicketCategoryResponseDTO> CreateTicketCategoryAsync(TicketCategoryRequestDTO ticketCategoryRequestDTO);
        Task<TicketCategoryResponseDTO> UpdateTicketCategoryAsync(int id, TicketCategoryRequestDTO ticketCategoryRequestDTO);
        Task<string> DeleteTicketCategoryAsync(int id);
        Task SaveChangesAsync();
    }
}
