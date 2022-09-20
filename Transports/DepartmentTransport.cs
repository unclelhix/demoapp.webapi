using DemoApplication.WebAPI.Models;
using Mapster;

namespace DemoApplication.WebAPI.Transports
{
    public class DepartmentTransport : BaseCodeTransport, IRegister
    {
        public List<DepartmentGroupTransport>? DepartmentGroupTransport { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Department, DepartmentTransport>()
                .IgnoreNullValues(true); 

            config.NewConfig<DepartmentTransport, Department>()
                .IgnoreNullValues(true); 
        }
    }
}
