using Application.Features.Duties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Duties.Commands.Create;

public class CreateDutyCommand : IRequest<CreatedDutyResponse>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool IsCompleted { get; set; }
    public required Guid UserId { get; set; }

    public class CreateDutyCommandHandler : IRequestHandler<CreateDutyCommand, CreatedDutyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDutyRepository _dutyRepository;
        private readonly DutyBusinessRules _dutyBusinessRules;

        public CreateDutyCommandHandler(IMapper mapper, IDutyRepository dutyRepository,
                                         DutyBusinessRules dutyBusinessRules)
        {
            _mapper = mapper;
            _dutyRepository = dutyRepository;
            _dutyBusinessRules = dutyBusinessRules;
        }

        public async Task<CreatedDutyResponse> Handle(CreateDutyCommand request, CancellationToken cancellationToken)
        {
            Duty duty = _mapper.Map<Duty>(request);

            await _dutyRepository.AddAsync(duty);

            CreatedDutyResponse response = _mapper.Map<CreatedDutyResponse>(duty);
            return response;
        }
    }
}