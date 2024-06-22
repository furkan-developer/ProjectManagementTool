using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore;
using ProjectManagement.DataAccess.EFCore.Repositories;

namespace ProjectManagement.DataAccess
{
    public static class ServiceRegistration
    {
        public static void RegisterDataAccessServices(this IServiceCollection services, IConfiguration builder)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISubJobRepository, SubJobRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddDbContext<AppDbContext>(
                     options => options.UseSqlServer(builder.GetConnectionString("SqlServer")));
        }
    }
}