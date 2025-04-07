using FamilyTree.Domain;
using FamilyTree.Infrastructure.Persistence;
using FamilyTree.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Infrastructure.Common.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Family> FamilySet => Set<Family>();
    public DbSet<Person> PersonSet => Set<Person>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FamilyMapping());
        modelBuilder.ApplyConfiguration(new PersonMapping());

        var seedDataProvider = SeedDataProvider.GetBasicInstance();
        modelBuilder.ApplyConfiguration(new GenericSeeder<Family>(seedDataProvider.FamilyData));
        modelBuilder.ApplyConfiguration(new GenericSeeder<Person>(seedDataProvider.PersonData));
    }
}
