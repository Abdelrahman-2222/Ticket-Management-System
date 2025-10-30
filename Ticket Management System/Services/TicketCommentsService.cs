using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.TicketCommentDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Service responsible for managing ticket comments.
    /// Handles creation, retrieval, updating, and deletion of <see cref="TicketComment"/> entities.
    /// </summary>
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


        /// <summary>
        /// Retrieves all ticket comments from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains a list of <see cref="TicketCommentResponseDTO"/> objects.
        /// </returns>
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



        /// <summary>
        /// Retrieves a specific ticket comment by its unique ID.
        /// </summary>
        /// <param name="id">The ID of the ticket comment to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the corresponding <see cref="TicketCommentResponseDTO"/> if found; otherwise, <c>null</c>.
        /// </returns>
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



        /// <summary>
        /// Creates a new ticket comment in the database.
        /// </summary>
        /// <param name="ticketCommentRequestDTO">The data used to create the new ticket comment.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the newly created <see cref="TicketCommentResponseDTO"/>.
        /// </returns>
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



        /// <summary>
        /// Updates an existing ticket comment in the database.
        /// </summary>
        /// <param name="id">The ID of the ticket comment to update.</param>
        /// <param name="ticketCommentRequestDTO">The updated data for the ticket comment.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the updated <see cref="TicketCommentResponseDTO"/>.
        /// </returns>
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



        /// <summary>
        /// Deletes a ticket comment from the database.
        /// </summary>
        /// <param name="id">The ID of the ticket comment to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains a confirmation message if the deletion was successful.
        /// </returns>
        public async Task<string> DeleteTicketCommentAsync(int id)
        {
            var ticketComment = await _context.TicketComments.FindAsync(id);

            if (ticketComment == null)
                throw new KeyNotFoundException($"Ticket Comment with ID {id} not found.");

            _context.TicketComments.Remove(ticketComment);

            await SaveChangesAsync();

            return $"Ticket Comment with Id {id} deleted successfully";
        }



        /// <summary>
        /// Saves all pending changes to the database asynchronously.
        /// </summary>
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
