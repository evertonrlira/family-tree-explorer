using FamilyTree.Domain;

namespace FamilyTree.Application.Common.Interfaces;

public interface IFamilyRepository
{
    Task<List<Family>> GetFamiliesAsync();
    Task<List<Person>> GetMembersByFamilyIdAsync(Guid familyId);
}
