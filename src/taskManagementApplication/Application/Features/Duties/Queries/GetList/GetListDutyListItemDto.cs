using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Duties.Queries.GetList;

public class GetListDutyListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Guid UserId { get; set; }
}