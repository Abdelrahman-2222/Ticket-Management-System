using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a department within the organization.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="IBaseId"/> and <see cref="IBaseName"/> to provide common identity and naming.
    /// </remarks>
    public class Department : IBaseId, IBaseName
    {
        /// <summary>
        /// Gets or sets the unique identifier for the department.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the department name.
        /// </summary>
        /// <remarks>
        /// The length is constrained by <see cref="AnnotationSettings.NameMinLength"/> and <see cref="AnnotationSettings.NameMaxLength"/>.
        /// </remarks>
        [MinLength(AnnotationSettings.NameMinLength), MaxLength(AnnotationSettings.NameMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of employees that belong to this department.
        /// </summary>
        /// <remarks>
        /// This is a navigation property used by Entity Framework to represent the one-to-many relationship from department to employees.
        /// </remarks>
        public ICollection<Employee> Employees { get; set; }
    }
}
