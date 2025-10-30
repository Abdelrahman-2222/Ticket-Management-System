using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.DTOs.TicketStatusDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Provides operations for querying and managing <see cref="TicketStatus"/> entities.
    /// </summary>
    /// <remarks>
    /// Uses Entity Framework Core via <see cref="TicketContext"/> and returns DTOs tailored for API responses.
    /// </remarks>
    public class TicketStatusService : ITicketStatusService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketStatusService"/> class.
        /// </summary>
        /// <param name="context">The EF Core database context.</param>
        public TicketStatusService(TicketContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a ticket status by its unique identifier, including a projection of related tickets.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket status.</param>
        /// <returns>
        /// A <see cref="TicketStatusResponeMainDTO"/> representing the status and its related tickets.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no status with the provided <paramref name="id"/> exists,
        /// or when multiple statuses match the provided <paramref name="id"/>.
        /// </exception>
        public async Task<TicketStatusResponeMainDTO> GetTicketStatusByIdAsync(int id)
        {
            var ticketStatus = await _context.TicketStatuses.Select(tS => new TicketStatusResponeMainDTO
            {
                Id = tS.Id,
                TicketStatusName = tS.Name,
                TicketDTO = tS.Tickets.Select(t => new TicketGetForStatusDTO
                {
                    Id = t.Id,
                    Title = t.Name,
                    Description = t.Description,
                    SubmittedAt = t.SubmittedAt
                }).ToList()
            }).SingleAsync(tS => tS.Id == id);
            return ticketStatus;

        }

        /// <summary>
        /// Retrieves all ticket statuses, including a projection of their related tickets.
        /// </summary>
        /// <returns>A list of <see cref="TicketStatusResponeMainDTO"/> instances.</returns>
        public async Task<List<TicketStatusResponeMainDTO>> GetAllTicketStatusesAsync()
        {
            var getAllTicketStatuses = await _context.TicketStatuses.Select(tS => new TicketStatusResponeMainDTO
            {
                Id = tS.Id,
                TicketStatusName = tS.Name,
                TicketDTO = tS.Tickets.Select(t => new TicketGetForStatusDTO
                {
                    Id = t.Id,
                    Title = t.Name,
                    Description = t.Description,
                    SubmittedAt = t.SubmittedAt
                }).ToList()
            }).ToListAsync();
            return getAllTicketStatuses;
        }

        /// <summary>
        /// Creates a new ticket status.
        /// </summary>
        /// <param name="ticketStatusRequestDTO">The request DTO containing the status name.</param>
        /// <returns>The created status as a <see cref="TicketStatusResponseDTO"/>.</returns>
        public async Task<TicketStatusResponseDTO> CreateTicketStatusAsync(TicketStatusInsertRequestDTO ticketStatusRequestDTO)
        {
            var newTicketStatus = new TicketStatus
            {
                Name = ticketStatusRequestDTO.TicketStatusName
            };
            await _context.TicketStatuses.AddAsync(newTicketStatus);
            await _context.SaveChangesAsync();
            return new TicketStatusResponseDTO
            {
                Id = newTicketStatus.Id,
                TicketStatusName = newTicketStatus.Name
            };
        }

        /// <summary>
        /// Updates an existing ticket status.
        /// </summary>
        /// <param name="id">The unique identifier of the status to update.</param>
        /// <param name="ticketStatusUpdateRequestDTO">The request DTO containing updated values.</param>
        /// <returns>
        /// A <see cref="TicketStatusUpdateResponseDTO"/> containing the old and new versions,
        /// or <see langword="null"/> if the status does not exist.
        /// </returns>
        public async Task<TicketStatusUpdateResponseDTO> UpdateTicketStatusAsync(int id, TicketStatusInsertRequestDTO ticketStatusUpdateRequestDTO)
        {
            var existingTicketStatus = await _context.TicketStatuses.FindAsync(id);
            if (existingTicketStatus == null)
            {
                return null;
            }
            var oldVersion = new TicketStatusResponseDTO
            {
                Id = existingTicketStatus.Id,
                TicketStatusName = existingTicketStatus.Name
            };
            existingTicketStatus.Name = ticketStatusUpdateRequestDTO.TicketStatusName;
            await _context.SaveChangesAsync();
            var newVersion = new TicketStatusResponseDTO
            {
                Id = existingTicketStatus.Id,
                TicketStatusName = existingTicketStatus.Name
            };
            return new TicketStatusUpdateResponseDTO
            {
                OldVersion = oldVersion,
                NewVersion = newVersion
            };
        }

        /// <summary>
        /// Deletes an existing ticket status by identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the status to delete.</param>
        /// <returns>
        /// A success message if deleted; otherwise <see langword="null"/> if the status was not found.
        /// </returns>
        public async Task<string> DeleteTicketStatusAsync(int id)
        {
            var existingTicketStatus = await _context.TicketStatuses.FindAsync(id);
            if (existingTicketStatus == null)
            {
                return null;
            }
            _context.TicketStatuses.Remove(existingTicketStatus);
            await _context.SaveChangesAsync();
            return $"Ticket status with ID {id} deleted successfully";
        }

        /// <summary>
        /// Persists all pending changes to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}