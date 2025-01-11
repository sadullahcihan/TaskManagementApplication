using NArchitecture.Core.Application.Responses;

namespace Application.Features.Duties.Commands.Delete;

public class DeletedDutyResponse : IResponse
{
    public Guid Id { get; set; }
}