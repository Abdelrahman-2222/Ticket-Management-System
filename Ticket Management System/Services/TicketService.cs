using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.DTOs.DepartmentDTO;
using Ticket_Management_System.DTOs.EmployeeDTO;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketCategoryDTO;
using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.DTOs.TicketPriorityDTO;
using Ticket_Management_System.DTOs.TicketStatusDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Services
{
    /// <summary>
    /// Provides ticket-related operations backed by Entity Framework Core.
    /// </summary>
    /// <remarks>
    /// This service encapsulates creation of tickets and persistence of changes using <see cref="TicketContext"/>.
    /// </remarks>
    public class TicketService : ITicketService
    {
        private readonly TicketContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketService"/> class.
        /// </summary>
        /// <param name="context">The EF Core <see cref="TicketContext"/> used to access the data store.</param>
        public TicketService(TicketContext context)
        {
            _context = context;
        }

        public async Task<TicketGetIdResponse> GetTicketByIdAsync(int id)
        {
            var ticket = await _context.Tickets
                .Select(T => new TicketGetIdResponse
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
                .FirstOrDefaultAsync();

            return ticket;
        }

        /// <summary>
        /// Creates a new <see cref="Ticket"/> with optional initial comments and assigned support agent.
        /// </summary>
        /// <param name="ticketRequestDTO">
        /// The request payload containing the ticket title, description, category, priority, optional support agent id,
        /// and optional initial comments.
        /// </param>
        /// <returns>
        /// A <see cref="TicketInsertResponseDTO"/> containing key details of the created ticket,
        /// including its identifier and submission timestamp.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="ticketRequestDTO"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// <list type="bullet">
        /// <item><description><c>Title</c> is null, empty, or whitespace.</description></item>
        /// <item><description><c>Description</c> is null, empty, or whitespace.</description></item>
        /// <item><description><c>SupportAgentId</c> is provided but does not reference an existing agent.</description></item>
        /// <item><description><c>TicketCategoryId</c> does not reference an existing category.</description></item>
        /// <item><description><c>TicketPriorityId</c> does not reference an existing priority.</description></item>
        /// <item><description>Any provided comment has empty or whitespace <c>Content</c>.</description></item>
        /// </list>
        /// </exception>
        /// <remarks>
        /// The method performs validation, creates the ticket and related comments, persists the changes,
        /// and returns a lightweight DTO of the created entity.
        /// </remarks>
        /// <seealso cref="Ticket"/>
        /// <seealso cref="TicketComment"/>
        public async Task<TicketInsertResponseDTO> CreateTicketAsync(TicketInsertRequestDTO ticketRequestDTO)
        {
            if (ticketRequestDTO == null)
                throw new ArgumentNullException(nameof(ticketRequestDTO));

            if (string.IsNullOrWhiteSpace(ticketRequestDTO.Title))
                throw new ArgumentException("Title is required.", nameof(ticketRequestDTO.Title));

            if (string.IsNullOrWhiteSpace(ticketRequestDTO.Description))
                throw new ArgumentException("Description is required.", nameof(ticketRequestDTO.Description));

            if (ticketRequestDTO.SupportAgentId.HasValue)
            {
                var agentExists = await _context.SupportAgents
                    .AnyAsync(sa => sa.Id == ticketRequestDTO.SupportAgentId.Value);

                if (!agentExists)
                    throw new ArgumentException("Invalid SupportAgentId.", nameof(ticketRequestDTO.SupportAgentId));
            }

            var categoryExists = await _context.TicketCategories
                .AnyAsync(c => c.Id == ticketRequestDTO.TicketCategoryId);
            if (!categoryExists)
                throw new ArgumentException("Invalid TicketCategoryId.", nameof(ticketRequestDTO.TicketCategoryId));

            var priorityExists = await _context.TicketPriorities
                .AnyAsync(p => p.Id == ticketRequestDTO.TicketPriorityId);
            if (!priorityExists)
                throw new ArgumentException("Invalid TicketPriorityId.", nameof(ticketRequestDTO.TicketPriorityId));

            if (ticketRequestDTO.Comments != null)
            {
                foreach (var comment in ticketRequestDTO.Comments)
                {
                    if (string.IsNullOrWhiteSpace(comment.Content))
                        throw new ArgumentException("Comment content cannot be empty.", nameof(comment.Content));
                }
            }

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
                SubmittedAt = newTicket.SubmittedAt.HasValue ? newTicket.SubmittedAt.Value.UtcDateTime : default(DateTime),
            };
        }

        /// <summary>
        /// Persists any pending changes in the underlying <see cref="TicketContext"/> to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        public async Task<List<TicketGetIdResponse>> GetAllTicketsAsync()
        {
            var tickets = await _context.Tickets
                .Select(T => new TicketGetIdResponse
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

        public async Task<TicketUpdateResponeDTO> UpdateTicketAsync(int id, TicketUpdateRequestDTO ticketUpdateRequestDTO)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }
            ticket.Name = ticketUpdateRequestDTO.Title;
            ticket.Description = ticketUpdateRequestDTO.Description;
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            var responseDTO = new TicketUpdateResponeDTO
            {
                Id = ticket.Id,
                Title = ticket.Name,
                Description = ticket.Description
            };
            return responseDTO;
        }

        public async Task<string> DeleteTicketAsync(int id)
        {
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
