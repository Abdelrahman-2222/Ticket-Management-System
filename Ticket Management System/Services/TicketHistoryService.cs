using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.TicketHistoryDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    public class TicketHistoryService : ITicketHistoryService
    {
        private readonly TicketContext _context;
        public TicketHistoryService(TicketContext ticketContext)
        {
            _context = ticketContext;
        }

        // GET by ID
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

        // GET all
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

        public async Task<string> DeleteTicketHistoryAsync(int id)
        {
            var ticketHistory = await _context.TicketHistories.FindAsync(id);
            if (ticketHistory == null)
                return "Ticket history not found";

            _context.TicketHistories.Remove(ticketHistory);
            await _context.SaveChangesAsync();
            return "Ticket history deleted successfully";
        }

        // POST
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
