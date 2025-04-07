using FamilyTree.Contracts.Responses;
using FamilyTree.Domain;

namespace FamilyTree.Api.Mapping;

public static class ContractMapping
{
    public static FamilyResponse MapToResponse(this Family family)
    {
        return new FamilyResponse
        {
            Id = family.Id,
            Name = family.Name
        };
    }

    public static PersonResponse MapToResponse(this Person person)
    {
        return new PersonResponse
        {
            Id = person.Id,
            Display = $"{person.GivenName} {person.SurName} {person.LifespanDisplay}"
        };
    }
}



