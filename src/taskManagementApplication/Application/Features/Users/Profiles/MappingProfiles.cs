using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreatedUserResponse>();

        CreateMap<UpdateUserCommand, User>();
        CreateMap<User, UpdatedUserResponse>();

        CreateMap<DeleteUserCommand, User>();
        CreateMap<User, DeletedUserResponse>();

        CreateMap<User, GetByIdUserResponse>();

        CreateMap<User, GetListUserListItemDto>();
        CreateMap<IPaginate<User>, GetListResponse<GetListUserListItemDto>>();
    }
}