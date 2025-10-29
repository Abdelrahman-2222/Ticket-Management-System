using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketService
    {
        // Define method signatures for ticket management operations
        // POST /api/tickets (Create a new Ticket)
        Task<TicketInsertResponseDTO> CreateTicketAsync(TicketInsertRequestDTO ticketRequestDTO);
        // GET /api/tickets (Get all Tickets)
        // GET /api/tickets/{id} (Get a Ticket by ID)
        // PUT /api/tickets/{id} (Update a Ticket by ID)
        // DELETE /api/tickets/{id} (Delete a Ticket by ID)
    }
}
