namespace FamilyTree.Contracts.Responses;

public record FamilyResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}
