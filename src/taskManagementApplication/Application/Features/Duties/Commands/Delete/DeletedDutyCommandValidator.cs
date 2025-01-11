using FluentValidation;

namespace Application.Features.Duties.Commands.Delete;

public class DeleteDutyCommandValidator : AbstractValidator<DeleteDutyCommand>
{
    public DeleteDutyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}