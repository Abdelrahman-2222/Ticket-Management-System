using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Service class responsible for managing Support Agent operations,
    /// including retrieving, creating, updating, and deleting support agents.
    /// </summary>
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


        /// <summary>
        /// Retrieves all support agents along with their associated tickets.
        /// </summary>
        /// <returns>
        /// A list of <see cref="SupportAgentGetByIdResponseDTO"/> objects containing details of all support agents and their tickets.
        /// </returns>
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


        /// <summary>
        /// Retrieves a single support agent by their unique identifier, including their tickets.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent.</param>
        /// <returns>
        /// A <see cref="SupportAgentGetByIdResponseDTO"/> object containing the support agent’s details and their tickets.
        /// Returns <c>null</c> if the support agent is not found.
        /// </returns>
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


        /// <summary>
        /// Creates a new support agent in the system.
        /// </summary>
        /// <param name="supportAgentRequestDTO">The data transfer object containing support agent details to be created.</param>
        /// <returns>
        /// A <see cref="SupportAgentGetByIdResponseDTO"/> containing the newly created support agent’s details.
        /// </returns>
        public async Task<SupportAgentGetByIdResponseDTO> CreateSupportAgentAsync(SupportAgentRequestDTO supportAgentRequestDTO)
        {
            var supportAgent = new SupportAgent
            {
                Name = supportAgentRequestDTO.Name,
                Specialization = supportAgentRequestDTO.Specialization
            };

            _context.SupportAgents.Add(supportAgent);
            await _context.SupportAgents.AddAsync(supportAgent);
            await SaveChangesAsync();

            return new SupportAgentGetByIdResponseDTO
            {
                Id = supportAgent.Id,
                Name = supportAgent.Name,
                Specialization = supportAgent.Specialization
            };
        }



        /// <summary>
        /// Updates an existing support agent’s information.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent to update.</param>
        /// <param name="supportAgentRequestDTO">The updated details for the support agent.</param>
        /// <returns>
        /// A <see cref="SupportAgentGetByIdResponseDTO"/> containing the updated support agent’s details.
        /// </returns>
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

            await SaveChangesAsync();

            var responseDTO = new SupportAgentGetByIdResponseDTO
            {
                Id = supportAgent.Id,
                Name = supportAgent.Name,
                Specialization = supportAgent.Specialization
            };

            return responseDTO;
        }



        /// <summary>
        /// Deletes a support agent from the system by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent to delete.</param>
        /// <returns>
        /// A confirmation message indicating that the support agent has been deleted.
        /// </returns>
        public async Task<string> DeleteSupportAgentAsync(int id)
        {
            var supportAgent = await _context.SupportAgents.FindAsync(id);
            if (supportAgent == null)
            {
                throw new KeyNotFoundException($"Support Agent with ID {id} not found.");
            }

            _context.SupportAgents.Remove(supportAgent);

            await SaveChangesAsync();

            return $"Support Agent with ID {id} has been deleted.";
        }


        /// <summary>
        /// Persists all pending changes made in the current database context.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
