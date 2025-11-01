using System.ComponentModel.DataAnnotations;
using Ticket_Management_System.AppAnnotation;
using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    /// <summary>
    /// Represents a department within the organization.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="EntityBase"/> and <see cref="NamedEntityBase"/> to provide common identity and naming.
    /// </remarks>
    public class Department : NamedEntityBase
    {

        /// <summary>
        /// Gets or sets the collection of employees that belong to this department.
        /// </summary>
        /// <remarks>
        /// This is a navigation property used by Entity Framework to represent the one-to-many relationship from department to employees.
        /// </remarks>
        public ICollection<Employee> Employees { get; set; }
    }
}
