using FluentValidation;

namespace Application.Features.Duties.Commands.Update;

public class UpdateDutyCommandValidator : AbstractValidator<UpdateDutyCommand>
{
    public UpdateDutyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.IsCompleted).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}