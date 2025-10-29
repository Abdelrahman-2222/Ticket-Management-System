using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    public class SupportAgentService : ISupportAgentService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupportAgentService"/> class.
        /// </summary>
        /// <param name="context">The EF Core <see cref="TicketContext"/> used to access the data store.</param>
        public SupportAgentService(TicketContext context)
        {
            _context = context;
        }

        public async Task<List<SupportAgentGetByIdResponseDTO>> GetAllSupportAgentsAsync()
        {
            var supportAgents = await _context.SupportAgents
                .Select(sa => new SupportAgentGetByIdResponseDTO
                {
                    Id = sa.Id,
                    Name = sa.Name,
                    Specialization = sa.Specialization,
                    Tickets = sa.Tickets.Select(t => new TicketInsertResponseDTO
                    {
                        Id = t.Id,
                        Title = t.Name,
                        Description = t.Description,
                        SupportAgentName = t.SupportAgent.Name,
                    }).ToList(),
                }).ToListAsync();
            return supportAgents;
        }

        public async Task<SupportAgentGetByIdResponseDTO> GetSupportAgentByIdAsync(int id)
        {
            var supportAgent = await _context.SupportAgents
                .Select(sa => new SupportAgentGetByIdResponseDTO
                {
                    Id = sa.Id,
                    Name = sa.Name,
                    Specialization = sa.Specialization,
                    Tickets = sa.Tickets.Select(t => new TicketInsertResponseDTO
                    {
                        Id = t.Id,
                        Title = t.Name,
                        Description = t.Description,
                        SupportAgentName = t.SupportAgent.Name,
                    }).ToList()
                })
                .FirstOrDefaultAsync(sa => sa.Id == id);

            if (supportAgent == null)
            {
                return null;
            }

            return supportAgent;
        }

        public async Task<SupportAgentGetByIdResponseDTO> CreateSupportAgentAsync(SupportAgentRequestDTO supportAgentRequestDTO)
        {
            var supportAgent = new SupportAgent
            {
                Name = supportAgentRequestDTO.Name,
                Specialization = supportAgentRequestDTO.Specialization
            };

            _context.SupportAgents.Add(supportAgent);
            SaveChangesAsync();

            return new SupportAgentGetByIdResponseDTO
            {
                Id = supportAgent.Id,
                Name = supportAgent.Name,
                Specialization = supportAgent.Specialization
            };
        }


        public async Task<SupportAgentGetByIdResponseDTO> UpdateSupportAgentAsync(int id, SupportAgentRequestDTO supportAgentRequestDTO)
        {
            var supportAgent = _context.SupportAgents.Find(id);
            if (supportAgent == null)
            {
                throw new KeyNotFoundException($"Support Agent with ID {id} not found.");
            }

            supportAgent.Id = id;
            supportAgent.Name = supportAgentRequestDTO.Name;
            supportAgent.Specialization = supportAgentRequestDTO.Specialization;

            _context.SupportAgents.Update(supportAgent);
            SaveChangesAsync();

            var responseDTO = new SupportAgentGetByIdResponseDTO
            {
                Id = supportAgent.Id,
                Name = supportAgent.Name,
                Specialization = supportAgent.Specialization
            };

            return responseDTO;
        }

        public async Task<string> DeleteSupportAgentAsync(int id)
        {
            var supportAgent = await _context.SupportAgents.FindAsync(id);
            if (supportAgent == null)
            {
                throw new KeyNotFoundException($"Support Agent with ID {id} not found.");
            }

            _context.SupportAgents.Remove(supportAgent);

            SaveChangesAsync();

            return $"Support Agent with ID {id} has been deleted.";
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
