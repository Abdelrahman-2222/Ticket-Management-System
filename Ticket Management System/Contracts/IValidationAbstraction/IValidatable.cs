using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.Contracts.IValidationAbstraction
{
    public interface IValidatable<T>
    {
        ValidationResult Validate(T dto);
    }
}
