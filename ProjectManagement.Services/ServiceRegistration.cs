using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Services.Contracts;
using ProjectManagement.Services.Services;

namespace ProjectManagement.Services
{
    public static class ServiceRegistration
    {
        public static void RegisterServicesServices(this IServiceCollection services)
        {
            services.AddScoped<IBoardService,BoardService>();
            services.AddScoped<IJobService,JobService>();
            services.AddScoped<IProjectService,ProjectService>();
        }
    }
}