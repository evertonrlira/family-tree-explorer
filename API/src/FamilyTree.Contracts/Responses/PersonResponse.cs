namespace FamilyTree.Contracts.Responses;

public record PersonResponse
{
    public required Guid Id { get; set; }
    public required string Display { get; init; }
}
