using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketCommentsService
    {
        Task<List<TicketCommentResponseDTO>> GetAllTicketCommentAsync();
        Task<TicketCommentResponseDTO> GetTicketCommentByIdAsync(int id);
        Task<TicketCommentResponseDTO> CreateTicketCommentAsync(TicketCommentRequestDTO ticketCommentRequestDTO);
        Task<TicketCommentResponseDTO> UpdateTicketCommentAsync(int id, TicketCommentRequestDTO ticketCommentRequestDTO);
        Task<string> DeleteTicketCommentAsync(int id);
        Task SaveChangesAsync();
    }
}
