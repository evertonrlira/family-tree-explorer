using System.Text.Json.Serialization;

namespace FamilyTree.Domain;

public class Person
{
    public Guid Id { get; set; }
    public string GivenName { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public GenderType Gender { get; set; } = GenderType.Unknown;
    public DateTime? BirthDate { get; init; } = null!;
    public string? BirthLocation { get; set; } = null!;
    public DateTime? DeathDate { get; init; } = null!;
    public string? DeathLocation { get; set; } = null!;

    [JsonIgnore]
    public Family Family { get; set; } = null!;
    [JsonIgnore]
    public Guid FamilyId { get; set; }

    [JsonIgnore]
    public string LifespanDisplay
    {
        get
        {
            // If the person has both a birth date and a death date, provide the lifespan as (BirthYear-DeathYear)
            if (BirthDate is not null && DeathDate is not null)
                return $"({BirthDate?.Year}-{DeathDate?.Year})";

            // If the person has only a death date, provide the lifespan as (-DeathYear)
            if (DeathDate is not null && BirthDate is null)
                return $"(-{DeathDate?.Year})";

            // If the person has neither a birth date nor a death date, provide the lifespan as (Living)
            if (BirthDate is null && DeathDate is null)
                return "(Living)";

            // If the person has no death date and has a birth date less than 120 years ago, provide the lifespan as (Living)
            if (DeathDate is null && BirthDate is not null && (DateTime.UtcNow - BirthDate.Value).TotalDays < 365 * 120)
                return "(Living)";

            // If the person has no death date and has a birth date 120 years ago or more, provide the lifespan as (BirthYear-)
            if (DeathDate is null && BirthDate is not null && (DateTime.UtcNow - BirthDate.Value).TotalDays >= 365 * 120)
                return $"({BirthDate?.Year}-)";

            return string.Empty;
        }
    }
}