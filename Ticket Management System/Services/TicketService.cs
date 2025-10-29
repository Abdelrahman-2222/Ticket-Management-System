using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Services
{
    public class TicketService : ITicketService
    {
        
        public Task<TicketInsertResponseDTO> CreateTicketAsync(TicketInsertRequestDTO ticketRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
