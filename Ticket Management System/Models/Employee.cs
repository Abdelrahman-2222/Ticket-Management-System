using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents an employee within the organization.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="IBaseId"/> and <see cref="IBaseName"/> to provide common identity and naming.
    /// Employees can submit tickets and belong to a single <see cref="Department"/>.
    /// </remarks>
    public class Employee : IBaseId, IBaseName
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        /// <remarks>
        /// The length is constrained by <see cref="AnnotationSettings.NameMinLength"/> and <see cref="AnnotationSettings.NameMaxLength"/>.
        /// </remarks>
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employee email address.
        /// </summary>
        /// <remarks>
        /// Validated against <see cref="AnnotationSettings.EmailPattern"/>.
        /// </remarks>
        [RegularExpression(AnnotationSettings.EmailPattern)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the employee's <see cref="Department"/>.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department this employee belongs to.
        /// </summary>
        /// <remarks>
        /// Navigation property used by Entity Framework to represent the many-to-one relationship.
        /// </remarks>
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets submitted by this employee.
        /// </summary>
        /// <remarks>
        /// Navigation property representing the one-to-many relationship between employee and tickets.
        /// </remarks>
        public ICollection<Ticket> Tickets { get; set; } 
    }
}
