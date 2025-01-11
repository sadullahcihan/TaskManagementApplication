using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Duties.Queries.GetList;

public class GetListDutyQuery : IRequest<GetListResponse<GetListDutyListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDutyQueryHandler : IRequestHandler<GetListDutyQuery, GetListResponse<GetListDutyListItemDto>>
    {
        private readonly IDutyRepository _dutyRepository;
        private readonly IMapper _mapper;

        public GetListDutyQueryHandler(IDutyRepository dutyRepository, IMapper mapper)
        {
            _dutyRepository = dutyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDutyListItemDto>> Handle(GetListDutyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Duty> duties = await _dutyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDutyListItemDto> response = _mapper.Map<GetListResponse<GetListDutyListItemDto>>(duties);
            return response;
        }
    }
}