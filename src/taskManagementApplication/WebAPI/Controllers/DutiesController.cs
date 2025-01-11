using Application.Features.Duties.Commands.Create;
using Application.Features.Duties.Commands.Delete;
using Application.Features.Duties.Commands.Update;
using Application.Features.Duties.Queries.GetById;
using Application.Features.Duties.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DutiesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDutyResponse>> Add([FromBody] CreateDutyCommand command)
    {
        CreatedDutyResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDutyResponse>> Update([FromBody] UpdateDutyCommand command)
    {
        UpdatedDutyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDutyResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDutyCommand command = new() { Id = id };

        DeletedDutyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDutyResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDutyQuery query = new() { Id = id };

        GetByIdDutyResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDutyListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDutyQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDutyListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}