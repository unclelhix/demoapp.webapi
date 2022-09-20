using DemoApplication.WebAPI.CustomMapper;
using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.DatabaseSeeder;
using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Services.ObjectMapping;
using DemoApplication.WebAPI.Shared.Contracts;
using DemoApplication.WebAPI.Shared.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.ServiceConfiguration
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration) {

            //Mapster Confgiguration
            var typeAdapterConfig = new TypeAdapterConfig();
            // scans the assembly and gets the IRegister
            var mappingRegistrations = TypeAdapterConfig.GlobalSettings.Scan(typeof(AssemblyReference).Assembly);

            // adds the registration to the TypeAdapterConfig
            mappingRegistrations.ToList().ForEach(register => register.Register(typeAdapterConfig));
            // register the mapper as Singleton service for this application
            var mapperConfig = new Mapper(typeAdapterConfig);

            services.AddSingleton<IMapper>(mapperConfig);

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

            services.AddScoped<ICustomMapper, CustoMapper>();

            return services;
        }
    }
}
