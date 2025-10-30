using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketCategoryDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Service responsible for managing ticket categories.
    /// Handles CRUD operations and database interactions for <see cref="TicketCategory"/> entities.
    /// </summary>
    public class TicketCategoryService : ITicketCategoryService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketCategoryService"/> class.
        /// </summary>
        /// <param name="context">The EF Core <see cref="TicketContext"/> used to access the data store.</param>
        public TicketCategoryService(TicketContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Retrieves all ticket categories from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains a list of <see cref="TicketCategoryResponseDTO"/> objects.
        /// </returns>
        public async Task<List<TicketCategoryResponseDTO>> GetAllTicketCategoryAsync()
        {
            var ticketCategories = await _context.TicketCategories
                .Select(C => new TicketCategoryResponseDTO
                {
                    Id = C.Id,
                    Name = C.Name,
                    Tickets = C.Tickets.Select(t => new TicketInsertResponseDTO
                    {
                        Id = t.Id,
                        Title = t.Name,
                        Description = t.Description,
                        SupportAgentName = t.SupportAgent.Name,
                    }).ToList(),
                }).ToListAsync();

            return ticketCategories;
        }


        /// <summary>
        /// Retrieves a specific ticket category by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket category to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the matching <see cref="TicketCategoryResponseDTO"/> if found; otherwise, <c>null</c>.
        /// </returns>
        public async Task<TicketCategoryResponseDTO> GetTicketCategoryByIdAsync(int id)
        { 
            var ticketCategory = await _context.TicketCategories
                .Select(sa => new TicketCategoryResponseDTO
                {
                    Id = sa.Id,
                    Name = sa.Name,
                    Tickets = sa.Tickets.Select(t => new TicketInsertResponseDTO
                    {
                        Id = t.Id,
                        Title = t.Name,
                        Description = t.Description,
                        SupportAgentName = t.SupportAgent.Name,
                    }).ToList()
                })
                .SingleOrDefaultAsync(sa => sa.Id == id);

            if (ticketCategory == null)
            {
                return null;
            }

            return ticketCategory;
        }


        /// <summary>
        /// Creates a new ticket category in the database.
        /// </summary>
        /// <param name="ticketCategoryRequestDTO">The data used to create the new ticket category.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the newly created <see cref="TicketCategoryResponseDTO"/>.
        /// </returns>
        public async Task<TicketCategoryResponseDTO> CreateTicketCategoryAsync(TicketCategoryRequestDTO ticketCategoryRequestDTO)
        {
            var ticketCategory = new TicketCategory
            {
                Name = ticketCategoryRequestDTO.Name,
            };

            await _context.TicketCategories.AddAsync(ticketCategory);
            await SaveChangesAsync();

            return new TicketCategoryResponseDTO
            {
                Id = ticketCategory.Id,
                Name = ticketCategory.Name,
            };
        }


        /// <summary>
        /// Updates an existing ticket category in the database.
        /// </summary>
        /// <param name="id">The ID of the ticket category to update.</param>
        /// <param name="ticketCategoryRequestDTO">The new data for the ticket category.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the updated <see cref="TicketCategoryResponseDTO"/>.
        /// </returns>
        public async Task<TicketCategoryResponseDTO> UpdateTicketCategoryAsync(int id, TicketCategoryRequestDTO ticketCategoryRequestDTO)
        {
            var ticketCategory = await _context.TicketCategories.FindAsync(id);
            if (ticketCategory == null)
            {
                throw new KeyNotFoundException($"Ticket Category Agent with ID {id} not found.");
            }

            ticketCategory.Name = ticketCategoryRequestDTO.Name;

            await SaveChangesAsync();

            var ticketCategoryDTO = new TicketCategoryResponseDTO
            {
                Id = ticketCategory.Id,
                Name = ticketCategory.Name,
            };

            return ticketCategoryDTO;
        }


        /// <summary>
        /// Deletes a ticket category from the database.
        /// </summary>
        /// <param name="id">The ID of the ticket category to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains a confirmation message if the deletion was successful.
        /// </returns>
        public async Task<string> DeleteTicketCategoryAsync(int id)
        {


            var ticketCategory = await _context.TicketCategories.FindAsync(id);
            if (ticketCategory == null)
            {
                throw new KeyNotFoundException($"Ticket Category Agent with ID {id} not found.");
            }

            _context.TicketCategories.Remove(ticketCategory);

            await SaveChangesAsync();

            return $"Ticket Category with ID {id} has been deleted.";
        }



        /// <summary>
        /// Persists all pending changes to the database asynchronously.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
