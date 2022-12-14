using DemoApplication.WebAPI.CustomMapperService;
using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.DatabaseSeeder;
using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Services.ObjectMapping;
using DemoApplication.WebAPI.Shared.Contracts;
using DemoApplication.WebAPI.Shared.Services;

using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.ServiceConfiguration
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IDateTimeService, DateTimeService>();       

            services.AddScoped<EmployeeSeeder>();
            services.AddScoped<DepartmentSeeder>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentGroupService, DepartmentGroupService>();

            services.AddScoped<IEmployeeMappingService, EmployeeMapping>();

            services.AddScoped<ICustomMapper, CustomMapper>();

            return services;
        }
    }
}
