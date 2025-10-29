using System.Threading.Tasks;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketService
    {
        // GET /api/tickets/{id} (Get Ticket by Id)
        Task<TicketGetIdResponse> GetTicketByIdAsync(int id);
        // POST /api/tickets (Create a new Ticket)
        Task<TicketInsertResponseDTO> CreateTicketAsync(TicketInsertRequestDTO ticketRequestDTO);
        // GET /api/tickets (Get all Tickets)
        Task<List<TicketGetIdResponse>> GetAllTicketsAsync();
        // UPDATE /api/tickets/{id} (Update Ticket by Id)
        Task<TicketUpdateResponeDTO> UpdateTicketAsync(int id, TicketUpdateRequestDTO ticketUpdateRequestDTO);
        // DELETE /api/tickets/{id} (Delete Ticket by Id)
        Task<string> DeleteTicketAsync(int id);

        // Save Changes DB
        Task SaveChangesAsync();
    }
}
