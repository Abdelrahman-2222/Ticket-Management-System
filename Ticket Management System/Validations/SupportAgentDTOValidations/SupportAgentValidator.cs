using FluentValidation;
using Ticket_Management_System.DTOs.SupportAgentDTO;

namespace Ticket_Management_System.Validations.SupportAgentDTOValidations
{
    public class SupportAgentValidator : AbstractValidator<SupportAgentGetAllResponseDTO>
    {
        public SupportAgentValidator()
        {
            RuleFor(agent => agent.Name)
                .NotEmpty().WithMessage("Support agent name is required.")
                .MaximumLength(100).WithMessage("Support agent name cannot exceed 100 characters.");

            RuleFor(agent => agent.Specialization)
                .NotEmpty().WithMessage("Specialization is required.")
                .MaximumLength(50).WithMessage("Specialization cannot exceed 50 characters.");

            //RuleFor(agent => agent.Id)
            //    .Equal(0).WithMessage("Support agent ID must be a positive integer.");
        }
    }
}
