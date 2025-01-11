using Application.Features.Duties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Duties.Commands.Update;

public class UpdateDutyCommand : IRequest<UpdatedDutyResponse>
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool IsCompleted { get; set; }
    public required Guid UserId { get; set; }

    public class UpdateDutyCommandHandler : IRequestHandler<UpdateDutyCommand, UpdatedDutyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDutyRepository _dutyRepository;
        private readonly DutyBusinessRules _dutyBusinessRules;

        public UpdateDutyCommandHandler(IMapper mapper, IDutyRepository dutyRepository,
                                         DutyBusinessRules dutyBusinessRules)
        {
            _mapper = mapper;
            _dutyRepository = dutyRepository;
            _dutyBusinessRules = dutyBusinessRules;
        }

        public async Task<UpdatedDutyResponse> Handle(UpdateDutyCommand request, CancellationToken cancellationToken)
        {
            Duty? duty = await _dutyRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _dutyBusinessRules.DutyShouldExistWhenSelected(duty);
            duty = _mapper.Map(request, duty);

            await _dutyRepository.UpdateAsync(duty!);

            UpdatedDutyResponse response = _mapper.Map<UpdatedDutyResponse>(duty);
            return response;
        }
    }
}