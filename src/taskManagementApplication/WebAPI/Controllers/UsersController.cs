using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserResponse>> Add([FromBody] CreateUserCommand command)
    {
        CreatedUserResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserResponse>> Update([FromBody] UpdateUserCommand command)
    {
        UpdatedUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserCommand command = new() { Id = id };

        DeletedUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserQuery query = new() { Id = id };

        GetByIdUserResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}