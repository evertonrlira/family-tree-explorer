using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FamilyTree.Application.Common.Interfaces;
using FamilyTree.Infrastructure.Common.Persistence;
using FamilyTree.Infrastructure.Persistence;

namespace FamilyTree.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFamilyRepository, FamilyRepository>();
        services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("SqliteConnection"));
            },
            ServiceLifetime.Scoped,
            ServiceLifetime.Singleton
        );
        return services;
    }
}
