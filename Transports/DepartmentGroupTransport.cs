using DemoApplication.WebAPI.Models;
using Mapster;

namespace DemoApplication.WebAPI.Transports
{
    public class DepartmentGroupTransport : BaseCodeTransport, IRegister
    {
        public long DepartmentId { get; set; }
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DepartmentGroup, DepartmentGroupTransport>()
              .IgnoreNullValues(true); ;

            config.NewConfig<DepartmentGroupTransport, DepartmentGroup>()
                .IgnoreNullValues(true); ;
        }
    }
}
