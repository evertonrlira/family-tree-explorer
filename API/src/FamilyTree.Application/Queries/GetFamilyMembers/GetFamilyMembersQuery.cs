using ErrorOr;
using MediatR;
using FamilyTree.Domain;

namespace FamilyTree.Application.Queries.GetFamilyMembers;

public record GetFamilyMembersQuery : IRequest<ErrorOr<IEnumerable<Person>>>
{
    public Guid FamilyId { get; init; }

    public GetFamilyMembersQuery(Guid familyId)
    {
        FamilyId = familyId;
    }
}
