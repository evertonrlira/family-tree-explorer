using ErrorOr;
using MediatR;
using FamilyTree.Domain;

namespace FamilyTree.Application.Queries.GetFamilies;

public record GetFamiliesQuery : IRequest<ErrorOr<IEnumerable<Family>>>
{
    public GetFamiliesQuery()
    {
    }
}
