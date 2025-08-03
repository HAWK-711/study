using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Services
{
    public static class ServiceFactory
    {
        public static void AddServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"))
                .Select(t => new
                {
                    Service = t.GetInterfaces().FirstOrDefault(), // インターフェースがあれば使う
                    Implementation = t
                });

            foreach (var type in types)
            {
                if (type.Service != null)
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
                else
                {
                    services.AddScoped(type.Implementation); // インターフェースがない場合はクラスそのまま
                }
            }
        }
    }
}