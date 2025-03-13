using Hms.Application.Contracts.Persistence;
using Hms.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HmsDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("HrmConnectionString")));


            services.AddScoped(typeof(IHmsRepository<>), typeof(HmsRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            //services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            //services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}