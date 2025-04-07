using FamilyTree.Application.Common.Interfaces;
using FamilyTree.Domain;
using FamilyTree.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Infrastructure.Persistence;

public class FamilyRepository : IFamilyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public FamilyRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Family>> GetFamiliesAsync()
    {
        return _dbContext
            .FamilySet
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<List<Person>> GetMembersByFamilyIdAsync(Guid familyId)
    {
        return _dbContext
            .PersonSet
            .Where(p => p.FamilyId == familyId)
            .AsNoTracking()
            .ToListAsync();
    }
}
