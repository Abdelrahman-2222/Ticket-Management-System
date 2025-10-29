using System.Threading.Tasks;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketService
    {
        // POST /api/tickets (Create a new Ticket)
        Task<TicketInsertResponseDTO> CreateTicketAsync(TicketInsertRequestDTO ticketRequestDTO);

        // Save Changes DB
        Task SaveChangesAsync();
    }
}
