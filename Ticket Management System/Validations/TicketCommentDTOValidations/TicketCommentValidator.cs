using FluentValidation;
using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.Validations.TicketCommentDTOValidations
{
    public class TicketCommentValidator : AbstractValidator<TicketCommentRequestDTO>
    {
        public TicketCommentValidator()
        {
            RuleFor(tc => tc.TicketId)
                .GreaterThan(0).WithMessage("TicketId must be greater than 0.");

            RuleFor(tc => tc.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters.");

            RuleFor(tc => tc.AuthorName)
                .NotEmpty().WithMessage("AuthorName is required.")
                .MaximumLength(50).WithMessage("AuthorName cannot exceed 50 characters.");
        }
    }
}
