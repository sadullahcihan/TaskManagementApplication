using Application.Features.Duties.Constants;
using Application.Features.Duties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Duties.Commands.Delete;

public class DeleteDutyCommand : IRequest<DeletedDutyResponse>
{
    public Guid Id { get; set; }

    public class DeleteDutyCommandHandler : IRequestHandler<DeleteDutyCommand, DeletedDutyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDutyRepository _dutyRepository;
        private readonly DutyBusinessRules _dutyBusinessRules;

        public DeleteDutyCommandHandler(IMapper mapper, IDutyRepository dutyRepository,
                                         DutyBusinessRules dutyBusinessRules)
        {
            _mapper = mapper;
            _dutyRepository = dutyRepository;
            _dutyBusinessRules = dutyBusinessRules;
        }

        public async Task<DeletedDutyResponse> Handle(DeleteDutyCommand request, CancellationToken cancellationToken)
        {
            Duty? duty = await _dutyRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _dutyBusinessRules.DutyShouldExistWhenSelected(duty);

            await _dutyRepository.DeleteAsync(duty!);

            DeletedDutyResponse response = _mapper.Map<DeletedDutyResponse>(duty);
            return response;
        }
    }
}