using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Infrastucture.Data;
using MyApp.Infrastucture.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastucture
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrasturaDI(this IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;"));
            services.AddScoped<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
