using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppConfiguration;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    public class TicketComment : IBaseId
    {
        public int Id { get; set; }
        [MaxLength(AnnotationSettings.ContentMaxLength)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string EmployeeName { get; set; } 

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}
