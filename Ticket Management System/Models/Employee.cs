using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppConfiguration;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    public class Employee : IBaseId, IBaseName
    {
        public int Id { get; set; }
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; }
        [RegularExpression(AnnotationSettings.EmailPattern)]
        public string Email { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Ticket> Tickets { get; set; } 
    }
}
