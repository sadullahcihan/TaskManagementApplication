using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Duties;

public interface IDutyService
{
    Task<Duty?> GetAsync(
        Expression<Func<Duty, bool>> predicate,
        Func<IQueryable<Duty>, IIncludableQueryable<Duty, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Duty>?> GetListAsync(
        Expression<Func<Duty, bool>>? predicate = null,
        Func<IQueryable<Duty>, IOrderedQueryable<Duty>>? orderBy = null,
        Func<IQueryable<Duty>, IIncludableQueryable<Duty, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Duty> AddAsync(Duty duty);
    Task<Duty> UpdateAsync(Duty duty);
    Task<Duty> DeleteAsync(Duty duty, bool permanent = false);
}
