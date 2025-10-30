using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.TicketHistoryDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Provides business logic for managing Tickets History including creation, retrieval, updating, and deletion.
    /// </summary>
    public class TicketHistoryService : ITicketHistoryService
    {
        private readonly TicketContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="TicketHistoryService"/> class.
        /// </summary>
        /// <param name="context">The database context used to access ticket History data.</param>
        public TicketHistoryService(TicketContext ticketContext)
        {
            _context = ticketContext;
        }

        /// <summary>
        /// Retrieves ticket history by its ID.
        /// </summary>
        /// <param name="id">Ticket history ID</param>
        /// <returns>Returns ticket history details if found</returns>
        public async Task<TicketHistoryResponseGetByIdDTO> GetTicketHistoryByIdAsync(int id)
        {
            var ticket = await _context.TicketHistories.Select(TH => new TicketHistoryResponseGetByIdDTO
            {
                Id = id,
                ChangeDescription = TH.ChangeDescription,
                Timestamp = TH.Timestamp,
                TicketName = TH.Ticket.Name
            }).SingleOrDefaultAsync(i => i.Id == id);
            if (ticket == null)
                return null;
            return ticket;
        }

        /// <summary>
        /// Retrieves all ticket histories.
        /// </summary>
        /// <returns>List of all ticket histories</returns>
        public async Task<List<TicketHistoryResponseGetByIdDTO>> GetAllTicketHistoriesAsync()
        {
            var ticketHistories = await _context.TicketHistories.Select(TH => new TicketHistoryResponseGetByIdDTO
            {
                Id = TH.Id,
                ChangeDescription = TH.ChangeDescription,
                Timestamp = TH.Timestamp,
                TicketName = TH.Ticket.Name
            }).ToListAsync();
            if (ticketHistories == null || ticketHistories.Count == 0)
                return null;
            return ticketHistories;
        }

        /// <summary>
        /// Updates ticket history by ID.
        /// </summary>
        /// <param name="id">Ticket history ID</param>
        /// <param name="ticketHistoryUpdateRequestDTO">Updated ticket history data</param>
        /// <returns>Returns updated ticket history details</returns>
        public async Task<TicketHistoryResponseGetByIdDTO> UpdateTicketHistoryAsync(int id, TicketHistoryUpdateRequestDTO ticketHistoryUpdateRequestDTO)
        {
            var ticketHistory = await _context.TicketHistories.FindAsync(id);
            if (ticketHistory == null)
                return null;

            ticketHistory.ChangeDescription = ticketHistoryUpdateRequestDTO.ChangeDescription;
            ticketHistory.Timestamp = ticketHistoryUpdateRequestDTO.Timestamp;

            await _context.SaveChangesAsync();

            return new TicketHistoryResponseGetByIdDTO
            {
                ChangeDescription = ticketHistory.ChangeDescription,
                Timestamp = ticketHistory.Timestamp,
                TicketName = ticketHistory.Ticket.Name
            };
        }

        /// <summary>
        /// Deletes ticket history by ID.
        /// </summary>
        /// <param name="id">Ticket history ID</param>
        /// <returns>String response message</returns>
        public async Task<string> DeleteTicketHistoryAsync(int id)
        {
            var ticketHistory = await _context.TicketHistories.FindAsync(id);
            if (ticketHistory == null)
                return "Ticket history not found";

            _context.TicketHistories.Remove(ticketHistory);
            await _context.SaveChangesAsync();
            return "Ticket history deleted successfully";
        }

        /// <summary>
        /// Creates a new ticket history entry.
        /// </summary>
        /// <param name="ticketHistoryInsertRequestDTO">New ticket history data</param>
        /// <returns>Returns created ticket history details</returns>
        public async Task<TicketHistoryResponseGetByIdDTO> CreateTicketHistoryAsync(TicketHistoryInsertRequestDTO ticketHistoryInsertRequestDTO)
        {
            var newTicketHistory = new TicketHistory
            {
                ChangeDescription = ticketHistoryInsertRequestDTO.ChangeDescription,
                Timestamp = ticketHistoryInsertRequestDTO.Timestamp,
                Ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketHistoryInsertRequestDTO.TicketId)
            };
            _context.TicketHistories.Add(newTicketHistory);
            await _context.SaveChangesAsync();
            return new TicketHistoryResponseGetByIdDTO
            {
                Id = newTicketHistory.Id,
                ChangeDescription = newTicketHistory.ChangeDescription,
                TicketName = newTicketHistory.Ticket.Name,
                Timestamp = newTicketHistory.Timestamp
            };
        }
    }
}
