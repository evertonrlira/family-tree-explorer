using ErrorOr;
using FamilyTree.Application.Common.Interfaces;
using FamilyTree.Domain;
using MediatR;

namespace FamilyTree.Application.Queries.GetFamilies;

public class GetFamiliesQueryHandler(IFamilyRepository familyRepository) : IRequestHandler<GetFamiliesQuery, ErrorOr<IEnumerable<Family>>>
{
    private readonly IFamilyRepository _familyRepository = familyRepository;

    public async Task<ErrorOr<IEnumerable<Family>>> Handle(GetFamiliesQuery request, CancellationToken cancellationToken)
    {
        return await _familyRepository.GetFamiliesAsync();
    }
}
