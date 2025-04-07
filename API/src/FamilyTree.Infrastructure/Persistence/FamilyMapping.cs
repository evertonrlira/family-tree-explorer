using FamilyTree.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTree.Infrastructure.Persistence;

public class FamilyMapping : IEntityTypeConfiguration<Family>
{
    public void Configure(EntityTypeBuilder<Family> builder)
    {
        builder
            .ToTable("FamilyTree")
            .HasKey(f => f.Id);

        builder
            .Property(f => f.Id)
            .ValueGeneratedNever();

        builder
            .Property(f => f.Name)
            .IsRequired();
    }
}
