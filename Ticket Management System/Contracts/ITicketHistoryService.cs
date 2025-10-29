using Ticket_Management_System.DTOs.TicketHistoryDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketHistoryService
    {
        // GET /api/ticketHistory/{id} (Get TicketHistory by Id)
        Task <TicketHistoryResponseGetByIdDTO> GetTicketHistoryByIdAsync(int id);
        // GET /api/ticketHistory (Get all TicketHistories)
        Task<List<TicketHistoryResponseGetByIdDTO>> GetAllTicketHistoriesAsync();
        //UPDATE /api/ticketHistory/{id} (Update TicketHistory by Id)
        Task<TicketHistoryResponseGetByIdDTO> UpdateTicketHistoryAsync(int id, TicketHistoryUpdateRequestDTO ticketHistoryUpdateRequestDTO);
         //DELETE /api/ticketHistory/{id} (Delete TicketHistory by Id)
        Task<string> DeleteTicketHistoryAsync(int id);
        // POST /api/ticketHistory (Create TicketHistory)
        Task<TicketHistoryResponseGetByIdDTO> CreateTicketHistoryAsync(TicketHistoryInsertRequestDTO ticketHistoryInsertRequestDTO);
    }
}
