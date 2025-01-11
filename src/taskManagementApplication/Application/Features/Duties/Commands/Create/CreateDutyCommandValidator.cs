using FluentValidation;

namespace Application.Features.Duties.Commands.Create;

public class CreateDutyCommandValidator : AbstractValidator<CreateDutyCommand>
{
    public CreateDutyCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.IsCompleted).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}