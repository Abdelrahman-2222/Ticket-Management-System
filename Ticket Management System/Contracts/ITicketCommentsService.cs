using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketCommentsService
    {
        Task<List<TicketCommentResponseDTO>> GetAllTicketCommentAsync();
        Task<TicketCommentResponseDTO> GetTicketCommentByIdAsync(int id);
        Task<TicketCommentResponseDTO> CreateTicketCommentAsync(TicketCommentRequestDTO ticketCommentRequestDTO);
        Task<TicketCommentResponseDTO> UpdateTicketCommentAsync(int id, TicketCommentRequestDTO ticketCommentRequestDTO);
        // Get All Comments related to a specific Ticket
        Task<List<TicketCommentResponseDTO>> GetCommentsByTicketIdAsync(int ticketId);
        Task<string> DeleteTicketCommentAsync(int id);
        Task SaveChangesAsync();
    }
}
