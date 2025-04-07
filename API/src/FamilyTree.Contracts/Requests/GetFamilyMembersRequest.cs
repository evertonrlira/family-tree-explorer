namespace FamilyTree.Contracts.Requests;

public record GetFamilyMembersRequest
{
    public required Guid FamilyId { get; init; }
}
