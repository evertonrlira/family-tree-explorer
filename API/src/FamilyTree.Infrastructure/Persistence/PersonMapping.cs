using FamilyTree.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTree.Infrastructure.Persistence;

public class PersonMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .ToTable("Person")
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.Family)
            .WithMany()
            .HasForeignKey(p => p.FamilyId)
            .IsRequired();

        builder
            .Property(p => p.Id)
            .ValueGeneratedNever();
        builder
            .Property(p => p.SurName)
            .IsRequired();
        builder
            .Property(p => p.GivenName)
            .IsRequired();
        builder
            .Property(p => p.Gender)
            .IsRequired();
        builder
            .Property(p => p.BirthDate)
            .IsRequired(false);
        builder
            .Property(p => p.BirthLocation)
            .IsRequired(false);
        builder
            .Property(p => p.DeathDate)
            .IsRequired(false);
        builder
            .Property(p => p.DeathLocation)
            .IsRequired(false);

        builder.HasIndex(p => p.FamilyId);
    }
}
