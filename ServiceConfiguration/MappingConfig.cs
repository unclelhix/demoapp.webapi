using DemoApplication.WebAPI.Services;
using Mapster;
using MapsterMapper;

namespace DemoApplication.WebAPI.ServiceConfiguration
{
    public static class MappingConfig
    {
        public static IServiceCollection AddMappingConfiguration(this IServiceCollection services) {

            //Mapster Confgiguration
            var typeAdapterConfig = new TypeAdapterConfig();
            // scans the assembly and gets the IRegister
            var mappingRegistrations = TypeAdapterConfig.GlobalSettings.Scan(typeof(AssemblyReference).Assembly);

            // adds the registration to the TypeAdapterConfig
            mappingRegistrations.ToList().ForEach(register => register.Register(typeAdapterConfig));
            // register the mapper as Singleton service for this application
            var mapperConfig = new Mapper(typeAdapterConfig);

            services.AddSingleton<IMapper>(mapperConfig);

            return services;
        }
    }
}
