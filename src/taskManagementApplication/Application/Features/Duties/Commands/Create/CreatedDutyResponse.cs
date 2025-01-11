using NArchitecture.Core.Application.Responses;

namespace Application.Features.Duties.Commands.Create;

public class CreatedDutyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Guid UserId { get; set; }
}