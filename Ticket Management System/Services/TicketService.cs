using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketCategoryDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.DTOs.TicketHistoryDTO;
using Ticket_Management_System.DTOs.TicketPriorityDTO;
using Ticket_Management_System.DTOs.TicketStatusDTO;
using Ticket_Management_System.Models;
using Ticket_Management_System.Services.SharedServiceValidations;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Provides business logic for managing tickets including creation, retrieval, updating, and deletion.
    /// </summary>
    public class TicketService : EnsureValid, ITicketService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketService"/> class.
        /// </summary>
        /// <param name="context">The database context used to access ticket data.</param>
        public TicketService(TicketContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a ticket by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket.</param>
        /// <returns>A <see cref="TicketGetIdResponseDTO"/> representing the ticket details if found; otherwise, null.</returns>
        public async Task<TicketGetIdResponseDTO> GetTicketByIdAsync(int id)
        {
            EnsureValidIDOnly<TicketGetIdResponseDTO>(id);
            var ticket = await _context.Tickets
                .Select(T => new TicketGetIdResponseDTO
                {
                    Id = T.Id,
                    Title = T.Name,
                    Description = T.Description,
                    ResolvedAt = T.ResolvedAt,
                    SubmittedAt = T.SubmittedAt,
                    SupportAgentName = new SupportAgentResponseDTO
                    {
                        Specialization = T.SupportAgent != null ? T.SupportAgent.Specialization : null,
                        Name = T.SupportAgent != null ? T.SupportAgent.Name : null
                    },
                    EmployeeName = new EmployeeResponseDTO
                    {
                        Id = T.Employee != null ? T.Employee.Id : 0,
                        Name = T.Employee != null ? T.Employee.Name : null,
                        Email = T.Employee != null ? T.Employee.Email : null,
                        Department = new DepartmentResponseDTO
                        {
                            Id = T.Employee != null && T.Employee.Department != null ? T.Employee.Department.Id : 0,
                            Name = T.Employee != null && T.Employee.Department != null ? T.Employee.Department.Name : null
                        }
                    },
                    TicketStatus = new TicketStatusResponseDTO
                    {
                        Id = T.Status != null ? T.Status.Id : 0,
                        TicketStatusName = T.Status != null ? T.Status.Name : null
                    },
                    TicketPriority = new TicketPriorityResponseDTO
                    {
                        Id = T.Priority != null ? T.Priority.Id : 0,
                        Name = T.Priority != null ? T.Priority.Name : null
                    },
                    TicketCategory = new TicketCategoryResponseDTO
                    {
                        Id = T.Category != null ? T.Category.Id : 0,
                        Name = T.Category != null ? T.Category.Name : null
                    }
                })
                .SingleOrDefaultAsync(i => i.Id == id);

            return ticket;
        }

        /// <summary>
        /// Creates a new ticket with the provided details.
        /// </summary>
        /// <param name="ticketRequestDTO">The request DTO containing the data for the new ticket.</param>
        /// <returns>A <see cref="TicketInsertResponseDTO"/> with the details of the created ticket.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the request DTO is null.</exception>
        /// <exception cref="ArgumentException">Thrown when required fields are missing or invalid.</exception>
        public async Task<TicketInsertResponseDTO> CreateTicketAsync(TicketInsertRequestDTO ticketRequestDTO)
        {
            EnsureValidDTOOnly<TicketInsertRequestDTO>(ticketRequestDTO);

            var newTicket = new Ticket
            {
                Name = ticketRequestDTO.Title.Trim(),
                Description = ticketRequestDTO.Description.Trim(),
                SupportAgentId = ticketRequestDTO.SupportAgentId,
                TicketCategoryId = ticketRequestDTO.TicketCategoryId,
                TicketPriorityId = ticketRequestDTO.TicketPriorityId,
                EmployeeId = ticketRequestDTO.EmployeeId,
                TicketStatusId = ticketRequestDTO.TicketStatusId,
                Comments = ticketRequestDTO.Comments?.Select(c => new TicketComment
                {
                    Content = c.Content.Trim(),
                    AuthorName = c.AuthorName?.Trim()
                }).ToList() ?? new List<TicketComment>()
            };

            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();

            var supportAgentName = newTicket.SupportAgentId.HasValue
                ? await _context.SupportAgents
                    .Where(sa => sa.Id == newTicket.SupportAgentId.Value)
                    .Select(sa => sa.Name)
                    .FirstOrDefaultAsync()
                : null;

            return new TicketInsertResponseDTO
            {
                Id = newTicket.Id,
                Title = newTicket.Name,
                Description = newTicket.Description,
                SupportAgentName = supportAgentName,
                SubmittedAt = newTicket.SubmittedAt.HasValue ? newTicket.SubmittedAt.Value.UtcDateTime : default,
            };
        }

        /// <summary>
        /// Persists any pending changes in the underlying <see cref="TicketContext"/> to the database.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all tickets in the system.
        /// </summary>
        /// <returns>A list of <see cref="TicketGetIdResponseDTO"/> representing ticket data.</returns>
        public async Task<List<TicketGetIdResponseDTO>> GetAllTicketsAsync()
        {
            var tickets = await _context.Tickets
                .Select(T => new TicketGetIdResponseDTO
                {
                    Id = T.Id,
                    Title = T.Name,
                    Description = T.Description,
                    ResolvedAt = T.ResolvedAt,
                    SubmittedAt = T.SubmittedAt,
                    SupportAgentName = new SupportAgentResponseDTO
                    {
                        Specialization = T.SupportAgent != null ? T.SupportAgent.Specialization : null,
                        Name = T.SupportAgent != null ? T.SupportAgent.Name : null
                    },
                    EmployeeName = new EmployeeResponseDTO
                    {
                        Id = T.Employee != null ? T.Employee.Id : 0,
                        Name = T.Employee != null ? T.Employee.Name : null,
                        Email = T.Employee != null ? T.Employee.Email : null,
                        Department = new DepartmentResponseDTO
                        {
                            Id = T.Employee != null && T.Employee.Department != null ? T.Employee.Department.Id : 0,
                            Name = T.Employee != null && T.Employee.Department != null ? T.Employee.Department.Name : null
                        }
                    },
                    TicketStatus = new TicketStatusResponseDTO
                    {
                        Id = T.Status != null ? T.Status.Id : 0,
                        TicketStatusName = T.Status != null ? T.Status.Name : null
                    },
                    TicketPriority = new TicketPriorityResponseDTO
                    {
                        Id = T.Priority != null ? T.Priority.Id : 0,
                        Name = T.Priority != null ? T.Priority.Name : null
                    },
                    TicketCategory = new TicketCategoryResponseDTO
                    {
                        Id = T.Category != null ? T.Category.Id : 0,
                        Name = T.Category != null ? T.Category.Name : null
                    }
                }).ToListAsync();

            return tickets;
        }

        /// <summary>
        /// Updates a ticket's title and description.
        /// </summary>
        /// <param name="id">The id of the ticket to update.</param>
        /// <param name="ticketUpdateRequestDTO">The request DTO containing new values.</param>
        /// <returns>A <see cref="TicketUpdateResponeDTO"/> containing updated data.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if ticket is not found.</exception>
        public async Task<TicketUpdateResponeDTO> UpdateTicketAsync(int id, TicketUpdateRequestDTO ticketUpdateRequestDTO)
        {
            EnsureValidDTOWithID<TicketUpdateRequestDTO>(ticketUpdateRequestDTO, id);
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }

            ticket.Name = ticketUpdateRequestDTO.Title;
            ticket.Description = ticketUpdateRequestDTO.Description;

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            return new TicketUpdateResponeDTO
            {
                Id = ticket.Id,
                Title = ticket.Name,
                Description = ticket.Description
            };
        }

        /// <summary>
        /// Deletes a ticket by its unique identifier.
        /// </summary>
        /// <param name="id">The id of the ticket to delete.</param>
        /// <returns>A confirmation message.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the ticket does not exist.</exception>
        public async Task<string> DeleteTicketAsync(int id)
        {
            EnsureValidIDOnly<TicketUpdateRequestDTO>(id);
            var ticketTobeDeleted = await _context.Tickets.FindAsync(id);
            if (ticketTobeDeleted == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }

            _context.Tickets.Remove(ticketTobeDeleted);
            await _context.SaveChangesAsync();

            return $"Ticket with ID {id} deleted successfully.";
        }
    }
}
