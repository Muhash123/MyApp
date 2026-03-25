
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Queries;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastucture
{
    public static class DependencyInjections
    {
       
             public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
