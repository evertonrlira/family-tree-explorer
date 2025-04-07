using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FamilyTree.Infrastructure.Seeders;

public class GenericSeeder<T>(IEnumerable<T> data) : IEntityTypeConfiguration<T> where T : class
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasData(data);
    }
}
