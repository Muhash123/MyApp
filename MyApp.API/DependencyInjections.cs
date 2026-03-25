using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR; // Ensure this using is here
using MyApp.Application.Queries;

namespace MyApp.Infrastucture
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            // Use 'services', not 'builder.Services'
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(GetAllStudentsQuery).Assembly);
            });

            // Ensure these names match your other extension methods exactly
            services.AddInfrasturaDI();
            services.AddApplicationDI();

            return services;
        }
    }
}