using Application.Features.Duties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Duties.Queries.GetById;

public class GetByIdDutyQuery : IRequest<GetByIdDutyResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDutyQueryHandler : IRequestHandler<GetByIdDutyQuery, GetByIdDutyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDutyRepository _dutyRepository;
        private readonly DutyBusinessRules _dutyBusinessRules;

        public GetByIdDutyQueryHandler(IMapper mapper, IDutyRepository dutyRepository, DutyBusinessRules dutyBusinessRules)
        {
            _mapper = mapper;
            _dutyRepository = dutyRepository;
            _dutyBusinessRules = dutyBusinessRules;
        }

        public async Task<GetByIdDutyResponse> Handle(GetByIdDutyQuery request, CancellationToken cancellationToken)
        {
            Duty? duty = await _dutyRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _dutyBusinessRules.DutyShouldExistWhenSelected(duty);

            GetByIdDutyResponse response = _mapper.Map<GetByIdDutyResponse>(duty);
            return response;
        }
    }
}