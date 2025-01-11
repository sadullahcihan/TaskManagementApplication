using Application.Features.Duties.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Duties.Rules;

public class DutyBusinessRules : BaseBusinessRules
{
    private readonly IDutyRepository _dutyRepository;
    private readonly ILocalizationService _localizationService;

    public DutyBusinessRules(IDutyRepository dutyRepository, ILocalizationService localizationService)
    {
        _dutyRepository = dutyRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DutiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DutyShouldExistWhenSelected(Duty? duty)
    {
        if (duty == null)
            await throwBusinessException(DutiesBusinessMessages.DutyNotExists);
    }

    public async Task DutyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Duty? duty = await _dutyRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DutyShouldExistWhenSelected(duty);
    }
}