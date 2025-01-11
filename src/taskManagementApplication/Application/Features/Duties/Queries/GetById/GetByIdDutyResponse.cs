using NArchitecture.Core.Application.Responses;

namespace Application.Features.Duties.Queries.GetById;

public class GetByIdDutyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Guid UserId { get; set; }
}