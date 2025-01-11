using NArchitecture.Core.Application.Responses;

namespace Application.Features.Duties.Commands.Update;

public class UpdatedDutyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Guid UserId { get; set; }
}