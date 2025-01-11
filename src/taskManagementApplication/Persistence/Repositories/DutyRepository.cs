using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DutyRepository : EfRepositoryBase<Duty, Guid, BaseDbContext>, IDutyRepository
{
    public DutyRepository(BaseDbContext context) : base(context)
    {
    }
}