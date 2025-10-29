using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.DTOs.TicketDTO
{
    public sealed class TicketInsertRequestDTO
    {
        [Required]
        public required string Title { get; init; }

        [Required]
        public required string Description { get; init; }
        public int EmployeeId { get; init; }

        public int? SupportAgentId { get; init; }

        [Required]
        public required int TicketCategoryId { get; init; }
        public int TicketStatusId { get; init; }

        public int TicketPriorityId { get; init; }

        public List<TicketCommentInsertRequestDTO> Comments { get; init; } = [];
    }
}