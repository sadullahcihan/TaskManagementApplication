using Application.Features.Duties.Commands.Create;
using Application.Features.Duties.Commands.Delete;
using Application.Features.Duties.Commands.Update;
using Application.Features.Duties.Queries.GetById;
using Application.Features.Duties.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Duties.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDutyCommand, Duty>();
        CreateMap<Duty, CreatedDutyResponse>();

        CreateMap<UpdateDutyCommand, Duty>();
        CreateMap<Duty, UpdatedDutyResponse>();

        CreateMap<DeleteDutyCommand, Duty>();
        CreateMap<Duty, DeletedDutyResponse>();

        CreateMap<Duty, GetByIdDutyResponse>();

        CreateMap<Duty, GetListDutyListItemDto>();
        CreateMap<IPaginate<Duty>, GetListResponse<GetListDutyListItemDto>>();
    }
}