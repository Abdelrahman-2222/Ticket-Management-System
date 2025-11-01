using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.DTOs.TicketPriorityDTO;
using Ticket_Management_System.Models;
using Ticket_Management_System.Services.SharedServiceValidations;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Provides services for managing ticket priorities including creation, retrieval, updating, and deletion operations.
    /// </summary>
    public class TicketPriorityService : EnsureValid, ITicketPriorityService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketPriorityService"/> class.
        /// </summary>
        /// <param name="context">The database context used to access ticket priority data.</param>
        public TicketPriorityService(TicketContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Persists any pending changes in the underlying <see cref="TicketContext"/> to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Creates a new ticket priority based on the provided request data.
        /// </summary>
        /// <param name="ticketPriorityRequestDTO">The DTO containing the ticket priority data.</param>
        /// <returns>The created <see cref="TicketPriorityResponseDTO"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the request DTO is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the name field is invalid.</exception>
        public async Task<TicketPriorityResponseDTO> CreateTicketPriorityAsync(TicketPriorityRequestDTO ticketPriorityRequestDTO)
        {
            EnsureValidDTOOnly<TicketPriorityRequestDTO>(ticketPriorityRequestDTO);

            var newTicketPriority = new TicketPriority
            {
                Name = ticketPriorityRequestDTO.Name.Trim()
            };

            _context.TicketPriorities.Add(newTicketPriority);
            await _context.SaveChangesAsync();

            return new TicketPriorityResponseDTO
            {
                Id = newTicketPriority.Id,
                Name = newTicketPriority.Name,
            };
        }

        /// <summary>
        /// Retrieves a ticket priority by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority.</param>
        /// <returns>The matching <see cref="TicketPriorityResponseDTO"/>, or null if not found.</returns>
        public async Task<TicketPriorityResponseDTO> GetTicketPriorityByIdAsync(int id)
        {
            EnsureValidIDOnly(id);
            var ticketPriority = await _context.TicketPriorities
                .Where(tp => tp.Id == id)
                .Select(tp => new TicketPriorityResponseDTO
                {
                    Id = tp.Id,
                    Name = tp.Name
                })
                .FirstOrDefaultAsync();

            if (ticketPriority == null)
            {
                return null;
            }

            return ticketPriority;
        }

        /// <summary>
        /// Retrieves all ticket priorities from the database.
        /// </summary>
        /// <returns>A list of <see cref="TicketPriorityResponseDTO"/> objects.</returns>
        public async Task<List<TicketPriorityResponseDTO>> GetAllTicketPrioritysAsync()
        {
            var ticketPrioritys = await _context.TicketPriorities
                .Select(tp => new TicketPriorityResponseDTO
                {
                    Id = tp.Id,
                    Name = tp.Name,
                }).ToListAsync();

            return ticketPrioritys;
        }

        /// <summary>
        /// Updates an existing ticket priority with the specified ID using the provided data.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority to update.</param>
        /// <param name="ticketPriorityRequestDTO">The DTO containing updated ticket priority data.</param>
        /// <returns>The updated <see cref="TicketPriorityResponseDTO"/>.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the ticket priority is not found.</exception>
        public async Task<TicketPriorityResponseDTO> UpdateTicketPriorityAsync(int id, TicketPriorityRequestDTO ticketPriorityRequestDTO)
        {
            EnsureValidDTOWithID<TicketPriorityRequestDTO>(ticketPriorityRequestDTO, id);
            var ticketPriority = await _context.TicketPriorities.FindAsync(id);

            if (ticketPriority == null)
            {
                return null;
            }

            ticketPriority.Name = ticketPriorityRequestDTO.Name;

            _context.TicketPriorities.Update(ticketPriority);
            await _context.SaveChangesAsync();

            return new TicketPriorityResponseDTO
            {
                Id = ticketPriority.Id,
                Name = ticketPriority.Name,
            };
        }

        /// <summary>
        /// Deletes a ticket priority by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority to delete.</param>
        /// <returns>A message indicating successful deletion.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the ticket priority is not found.</exception>
        public async Task<string> DeleteTicketPriorityAsync(int id)
        {
            EnsureValidIDOnly(id);
            var TicketPriorityTobeDeleted = await _context.TicketPriorities.FindAsync(id);
            if (TicketPriorityTobeDeleted == null)
            {
                return null;
            }

            _context.TicketPriorities.Remove(TicketPriorityTobeDeleted);
            await _context.SaveChangesAsync();

            return $"Ticket Priority with ID {id} deleted successfully.";
        }
        /// <summary>
        /// Return a ticket priority by its unique identifier with info on ticket details.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority to delete.</param>
        /// <returns>A specific ticket priority with it's ticket details.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the ticket priority is not found.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the ticket is not found.</exception>
        public async Task<TicketPriorityAllDetailsResponseDTO> GetAllTicketPriorityDetailsByIdAsync(int id)
        {
            var ticketPriorityDetails = await _context.TicketPriorities
                .Select(tp => new TicketPriorityAllDetailsResponseDTO
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Tickets = tp.Tickets.Select(t => new TicketGetForStatusDTO
                    {
                        Id = t.Id,
                        Title = t.Name,
                        Description = t.Description,
                        SubmittedAt = t.SubmittedAt
                    }).ToList()
                })
                .SingleOrDefaultAsync(tp => tp.Id == id);
            if (ticketPriorityDetails == null)
            {
                throw new KeyNotFoundException($"Ticket Priority with ID {id} not found.");
            }
            if (ticketPriorityDetails.Tickets == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }
            return ticketPriorityDetails;
        }
    }
}
