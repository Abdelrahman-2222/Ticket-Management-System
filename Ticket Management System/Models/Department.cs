using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppConfiguration;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    public class Department : IBaseId, IBaseName
    {
        public int Id { get; set; }
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; } 

        public ICollection<Employee> Employees { get; set; }
    }
}
