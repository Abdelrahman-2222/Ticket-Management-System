using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.TicketCommentDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    public class TicketCommentsService : ITicketCommentsService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketCommandsService"/> class.
        /// </summary>
        /// <param name="context">The EF Core <see cref="TicketContext"/> used to access the data store.</param>
        public TicketCommentsService(TicketContext context)
        {
            _context = context;
        }



        public async Task<List<TicketCommentResponseDTO>> GetAllTicketCommentAsync()
        {
            var ticketComments = await _context.TicketComments
                .Select(tc => new TicketCommentResponseDTO
                {
                    Id = tc.Id,
                    Content = tc.Content,
                    AuthorName = tc.AuthorName,
                    TicketName = tc.Ticket.Name,
                }).ToListAsync();

            return ticketComments;
        }


        public async Task<TicketCommentResponseDTO> GetTicketCommentByIdAsync(int id)
        {
            var ticketComment = await _context.TicketComments
                .Where(tc => tc.Id == id)
                .Select(tc => new TicketCommentResponseDTO
                {
                    Id = tc.Id,
                    Content = tc.Content,
                    AuthorName = tc.AuthorName,
                    TicketName = tc.Ticket.Name,
                }).FirstOrDefaultAsync();

            return ticketComment;
        }


        public async Task<TicketCommentResponseDTO> CreateTicketCommentAsync(TicketCommentRequestDTO ticketCommentRequestDTO)
        {
            var ticketName = await _context.Tickets
                .Where(t => t.Id == ticketCommentRequestDTO.TicketId)
                .Select(t => t.Name)
                .FirstOrDefaultAsync();

            var ticketComment = new TicketComment
            {
                Content = ticketCommentRequestDTO.Content,
                AuthorName = ticketCommentRequestDTO.AuthorName,
                TicketId = ticketCommentRequestDTO.TicketId,
            };

            _context.TicketComments.Add(ticketComment);

            await SaveChangesAsync();

            var responseDTO = new TicketCommentResponseDTO
            {
                Id = ticketComment.Id,
                Content = ticketComment.Content,
                AuthorName = ticketComment.AuthorName,
                TicketName = ticketName
            };

            return responseDTO;
        }


        public async Task<TicketCommentResponseDTO> UpdateTicketCommentAsync(int id, TicketCommentRequestDTO ticketCommentRequestDTO)
        {
            var ticketComment = await _context.TicketComments.FindAsync(id);

            if (ticketComment == null)
                throw new KeyNotFoundException($"Ticket Comment with ID {id} not found.");

            ticketComment.Content = ticketCommentRequestDTO.Content;
            ticketComment.AuthorName = ticketCommentRequestDTO.AuthorName;
            ticketComment.TicketId = ticketCommentRequestDTO.TicketId;

            await SaveChangesAsync();

            var ticketName = await _context.Tickets
                .Where(t => t.Id == ticketComment.TicketId)
                .Select(t => t.Name)
                .FirstOrDefaultAsync();

            var responseDTO = new TicketCommentResponseDTO
            {
                Id = ticketComment.Id,
                Content = ticketComment.Content,
                AuthorName = ticketComment.AuthorName,
                TicketName = ticketName
            };

            return responseDTO;
        }

        public async Task<string> DeleteTicketCommentAsync(int id)
        {
            var ticketComment = await _context.TicketComments.FindAsync(id);

            if (ticketComment == null)
                throw new KeyNotFoundException($"Ticket Comment with ID {id} not found.");

            _context.TicketComments.Remove(ticketComment);

            await SaveChangesAsync();

            return $"Ticket Comment with Id {id} deleted successfully";
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<TicketCommentResponseDTO>> GetCommentsByTicketIdAsync(int ticketId)
        {
            var comments = await _context.TicketComments
                .Where(tc => tc.TicketId == ticketId)
                .Select(tc => new TicketCommentResponseDTO
                {
                    Id = tc.Id,
                    Content = tc.Content,
                    AuthorName = tc.AuthorName,
                    TicketName = tc.Ticket.Name,
                }).ToListAsync();
            return comments;
        }
    }
}
