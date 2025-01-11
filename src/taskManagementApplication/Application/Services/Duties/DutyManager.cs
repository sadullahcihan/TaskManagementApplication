using Application.Features.Duties.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Duties;

public class DutyManager : IDutyService
{
    private readonly IDutyRepository _dutyRepository;
    private readonly DutyBusinessRules _dutyBusinessRules;

    public DutyManager(IDutyRepository dutyRepository, DutyBusinessRules dutyBusinessRules)
    {
        _dutyRepository = dutyRepository;
        _dutyBusinessRules = dutyBusinessRules;
    }

    public async Task<Duty?> GetAsync(
        Expression<Func<Duty, bool>> predicate,
        Func<IQueryable<Duty>, IIncludableQueryable<Duty, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Duty? duty = await _dutyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return duty;
    }

    public async Task<IPaginate<Duty>?> GetListAsync(
        Expression<Func<Duty, bool>>? predicate = null,
        Func<IQueryable<Duty>, IOrderedQueryable<Duty>>? orderBy = null,
        Func<IQueryable<Duty>, IIncludableQueryable<Duty, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Duty> dutyList = await _dutyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return dutyList;
    }

    public async Task<Duty> AddAsync(Duty duty)
    {
        Duty addedDuty = await _dutyRepository.AddAsync(duty);

        return addedDuty;
    }

    public async Task<Duty> UpdateAsync(Duty duty)
    {
        Duty updatedDuty = await _dutyRepository.UpdateAsync(duty);

        return updatedDuty;
    }

    public async Task<Duty> DeleteAsync(Duty duty, bool permanent = false)
    {
        Duty deletedDuty = await _dutyRepository.DeleteAsync(duty);

        return deletedDuty;
    }
}
