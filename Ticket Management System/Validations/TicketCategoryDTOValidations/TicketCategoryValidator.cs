using FluentValidation;
using Ticket_Management_System.DTOs.TicketCategoryDTO;

namespace Ticket_Management_System.Validations.TicketCategoryDTOValidations
{
    public class TicketCategoryValidator : AbstractValidator<TicketCategoryRequestDTO>
    {
        public TicketCategoryValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Ticket category name is required.")
                .MaximumLength(50).WithMessage("Ticket category name cannot exceed 50 characters.");
        }
    }
}