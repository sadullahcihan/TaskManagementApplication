using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Duty : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
