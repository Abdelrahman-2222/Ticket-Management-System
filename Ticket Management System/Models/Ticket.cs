using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppConfiguration;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    public class Ticket : IBaseId, IBaseName
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime? ResolvedAt { get; set; } 

        public int EmployeeId { get; set; }        
        public int? SupportAgentId { get; set; }     
        public int TicketStatusId { get; set; }
        public int TicketPriorityId { get; set; }
        public int TicketCategoryId { get; set; }

        public Employee Employee { get; set; }
        public SupportAgent SupportAgent { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketCategory Category { get; set; }

        public ICollection<TicketComment> Comments { get; set; }
        public ICollection<TicketHistory> HistoryLogs { get; set; }

    }
}
