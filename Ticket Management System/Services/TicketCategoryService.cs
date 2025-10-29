using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketCategoryDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
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

        

        public async Task<List<TicketCategoryResponseDTO>> GetAllTicketCategoryAsync()
        {
            var ticketCategories = _context.TicketCategories
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
                }).ToList();

            return ticketCategories;
        }


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
                .FirstOrDefaultAsync(sa => sa.Id == id);

            if (ticketCategory == null)
            {
                return null;
            }

            return ticketCategory;
        }


        public async Task<TicketCategoryResponseDTO> CreateTicketCategoryAsync(TicketCategoryRequestDTO ticketCategoryRequestDTO)
        {
            var ticketCategory = new TicketCategory
            {
                Name = ticketCategoryRequestDTO.Name,
            };

            _context.TicketCategories.Add(ticketCategory);
            SaveChangesAsync();

            return new TicketCategoryResponseDTO
            {
                Id = ticketCategory.Id,
                Name = ticketCategory.Name,
            };
        }

        

        public async Task<TicketCategoryResponseDTO> UpdateTicketCategoryAsync(int id, TicketCategoryRequestDTO ticketCategoryRequestDTO)
        {
            var ticketCategory = _context.TicketCategories.Find(id);
            if (ticketCategory == null)
            {
                throw new KeyNotFoundException($"Ticket Category Agent with ID {id} not found.");
            }

            ticketCategory.Id = id;
            ticketCategory.Name = ticketCategoryRequestDTO.Name;

            _context.TicketCategories.Update(ticketCategory);
            SaveChangesAsync();

            var ticketCategoryDTO = new TicketCategoryResponseDTO
            {
                Id = ticketCategory.Id,
                Name = ticketCategory.Name,
            };

            return ticketCategoryDTO;
        }


        public async Task<string> DeleteTicketCategoryAsync(int id)
        {


            var ticketCategory = await _context.TicketCategories.FindAsync(id);
            if (ticketCategory == null)
            {
                throw new KeyNotFoundException($"Ticket Category Agent with ID {id} not found.");
            }

            _context.TicketCategories.Remove(ticketCategory);

            SaveChangesAsync();

            return $"Ticket Category with ID {id} has been deleted.";
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
