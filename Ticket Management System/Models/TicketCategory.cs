using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppConfiguration;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    public class TicketCategory : IBaseId, IBaseName
    {
        public int Id { get; set; }
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
