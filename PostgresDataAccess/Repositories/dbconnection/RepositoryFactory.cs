using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using PostgresDataAccess.Repositories;

namespace Dbconnection
{
    public static class RepositoryFactory
    {
        private static string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

        public static void AddRepositories(this IServiceCollection services)
        {
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