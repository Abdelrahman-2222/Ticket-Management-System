using Ticket_Management_System.DTOs.SupportAgentDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ISupportAgentService
    {
        Task<List<SupportAgentGetByIdResponseDTO>> GetAllSupportAgentsAsync();
        Task<SupportAgentGetByIdResponseDTO> GetSupportAgentByIdAsync(int id);
        Task<SupportAgentGetByIdResponseDTO> CreateSupportAgentAsync(SupportAgentRequestDTO supportAgentRequestDTO);
        Task<SupportAgentGetByIdResponseDTO> UpdateSupportAgentAsync(int id, SupportAgentRequestDTO supportAgentRequestDTO);
        Task<string> DeleteSupportAgentAsync(int id);
        Task SaveChangesAsync();
    }
}
