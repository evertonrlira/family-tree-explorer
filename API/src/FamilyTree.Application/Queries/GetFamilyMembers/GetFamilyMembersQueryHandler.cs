using ErrorOr;
using FamilyTree.Application.Common.Interfaces;
using FamilyTree.Domain;
using MediatR;

namespace FamilyTree.Application.Queries.GetFamilyMembers;

public class GetFamilyMembersQueryHandler(IFamilyRepository familyRepository) : IRequestHandler<GetFamilyMembersQuery, ErrorOr<IEnumerable<Person>>>
{
    private readonly IFamilyRepository _familyRepository = familyRepository;

    public async Task<ErrorOr<IEnumerable<Person>>> Handle(GetFamilyMembersQuery request, CancellationToken cancellationToken)
    {
        return await _familyRepository.GetMembersByFamilyIdAsync(request.FamilyId);
    }
}
