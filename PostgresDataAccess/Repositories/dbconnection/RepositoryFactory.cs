using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostgresDataAccess.Models;

namespace PostgresDataAccess.Repositories.dbconnection
{
    public static class RepositoryFactory
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            var assembly = typeof(IUserRepository).Assembly;

            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"),
                    Implementation = t
                })
                .Where(x => x.Service != null);

            foreach (var type in types)
            {
                if (type.Service != null)
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
                else
                {
                    throw new InvalidOperationException($"No interface found for {type.Implementation.Name}");
                }
            }
        }
    }
}