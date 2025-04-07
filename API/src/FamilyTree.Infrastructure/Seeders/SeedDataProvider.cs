using FamilyTree.Domain;

namespace FamilyTree.Infrastructure.Seeders;

public class SeedDataProvider(List<Family> families, List<Person> familiesMembers)
{
    public List<Family> FamilyData = families;
    public List<Person> PersonData = familiesMembers;

    public static SeedDataProvider GetBasicInstance()
    {
        var taylorFamily = new Family { Id = Guid.NewGuid(), Name = "Taylor" };
        var jonesFamily = new Family { Id = Guid.NewGuid(), Name = "Jones" };
        var robinsonFamily = new Family { Id = Guid.NewGuid(), Name = "Robinson" };
        List<Family> families = [taylorFamily, jonesFamily, robinsonFamily];

        List<Person> taylorFamilyMembers = [
            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "William",
                SurName = "Taylor",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1950, 3, 10),
                DeathDate = new DateTime(2020, 5, 15),
                DeathLocation = "New York, USA",
                FamilyId = taylorFamily.Id
            }, // Lifespan: (1950-2020)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Elizabeth",
                SurName = "Taylor",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1925, 6, 2),
                DeathDate = new DateTime(2005, 12, 20),
                DeathLocation = "Los Angeles, USA",
                FamilyId = taylorFamily.Id
            }, // Lifespan: (1925-2005)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "George",
                SurName = "Taylor",
                Gender = GenderType.Male,
                BirthDate = null,
                DeathDate = new DateTime(1990, 8, 15),
                DeathLocation = "San Francisco, USA",
                FamilyId = taylorFamily.Id
            }, // Lifespan: (-1990) (Only death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Martha",
                SurName = "Taylor",
                Gender = GenderType.Female,
                BirthDate = null,
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = taylorFamily.Id
            }, // Lifespan: (Living) (No birth and death dates)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Benjamin",
                SurName = "Taylor",
                Gender = GenderType.Male,
                BirthDate = new DateTime(2000, 1, 1),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = taylorFamily.Id
            }, // Lifespan: (Living) (Birth date within the last 120 years, no Death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Catherine",
                SurName = "Taylor",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1890, 7, 18),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = taylorFamily.Id
            }, // Lifespan: (1890-) (Born more than 120 years ago, no Death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Henry",
                SurName = "Taylor",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1985, 10, 5),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = taylorFamily.Id
            }, // Lifespan: (Living) (Birth date within the last 120 years)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Alice",
                SurName = "Taylor",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1870, 9, 10),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = taylorFamily.Id
            }, // Lifespan: (1870-) (Born more than 120 years ago, no Death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Susan",
                SurName = "Taylor",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1940, 11, 25),
                DeathDate = new DateTime(2015, 4, 18),
                DeathLocation = "Boston, USA",
                FamilyId = taylorFamily.Id
            }, // Lifespan: (1940-2015)
        ];

        List<Person> jonesFamilyMembers = [
            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Edward",
                SurName = "Jones",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1965, 2, 20),
                DeathDate = new DateTime(2021, 9, 10),
                DeathLocation = "Houston, USA",
                FamilyId = jonesFamily.Id
            }, // Lifespan: (1965-2021)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Margaret",
                SurName = "Jones",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1910, 11, 13),
                DeathDate = new DateTime(1995, 7, 25),
                DeathLocation = "Dallas, USA",
                FamilyId = jonesFamily.Id
            }, // Lifespan: (1910-1995)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Arthur",
                SurName = "Jones",
                Gender = GenderType.Male,
                BirthDate = null,
                DeathDate = new DateTime(1982, 4, 2),
                DeathLocation = "Austin, USA",
                FamilyId = jonesFamily.Id
            }, // Lifespan: (-1982) (Only death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Helen",
                SurName = "Jones",
                Gender = GenderType.Female,
                BirthDate = null,
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = jonesFamily.Id
            }, // Lifespan: (Living) (No birth and death dates)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "John",
                SurName = "Jones",
                Gender = GenderType.Male,
                BirthDate = new DateTime(2005, 6, 17),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = jonesFamily.Id
            }, // Lifespan: (Living) (Birth date within the last 120 years, no Death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Clara",
                SurName = "Jones",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1900, 3, 5),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = jonesFamily.Id
            } // Lifespan: (1900-) (Born more than 120 years ago, no Death date)
        ];

        List<Person> robinsonFamilyMembers = [
            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "James",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1980, 7, 15),
                DeathDate = new DateTime(2050, 3, 30),
                DeathLocation = "Chicago, USA",
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (1980-2050)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Sophia",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1920, 11, 20),
                DeathDate = new DateTime(1995, 8, 10),
                DeathLocation = "Detroit, USA",
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (1920-1995)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "William",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1965, 5, 2),
                DeathDate = new DateTime(2022, 9, 17),
                DeathLocation = "Miami, USA",
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (1965-2022)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Alice",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = null,
                DeathDate = new DateTime(2000, 1, 25),
                DeathLocation = "Los Angeles, USA",
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (-2000)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Robert",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = null,
                DeathDate = new DateTime(1990, 7, 13),
                DeathLocation = "Dallas, USA",
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (-1990)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Eleanor",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = null,
                DeathDate = new DateTime(1985, 3, 10),
                DeathLocation = "Boston, USA",
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (-1985)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Liam",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = null,
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (Living) (No birth and death dates)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Emily",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = null,
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (Living) (No birth and death dates)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Jacob",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = null,
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (Living) (No birth and death dates)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Olivia",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = new DateTime(2000, 4, 10),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: Living (Birth date within the last 120 years, no Death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Daniel",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1995, 8, 15),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: Living (Birth date within the last 120 years, no Death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Charlotte",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = new DateTime(2010, 6, 3),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: Living (Birth date within the last 120 years, no Death date)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Charles",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1900, 2, 10),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (1900-)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Margaret",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = new DateTime(1625, 9, 5),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (1625-)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Samuel",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = new DateTime(1391, 12, 25),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (1391-)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Helen",
                SurName = "Robinson",
                Gender = GenderType.Female,
                BirthDate = new DateTime(894, 7, 18),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            }, // Lifespan: (894-)

            new Person
            {
                Id = Guid.NewGuid(),
                GivenName = "Frank",
                SurName = "Robinson",
                Gender = GenderType.Male,
                BirthDate = new DateTime(940, 10, 8),
                DeathDate = null,
                DeathLocation = string.Empty,
                FamilyId = robinsonFamily.Id
            } // Lifespan: (940-)
        ];

        return new SeedDataProvider(families, [.. taylorFamilyMembers, .. jonesFamilyMembers, .. robinsonFamilyMembers]);
    }
}
