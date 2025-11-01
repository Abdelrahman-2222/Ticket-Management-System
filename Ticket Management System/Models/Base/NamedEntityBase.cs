using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;

namespace Ticket_Management_System.Models.Base
{
    public abstract class NamedEntityBase : EntityBase
    {
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public virtual string Name { get; set; }
    }
}
