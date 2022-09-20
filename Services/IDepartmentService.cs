using DemoApplication.WebAPI.Shared.Contracts;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public interface IDepartmentService : IBaseServiceDataRepository<DepartmentTransport>
    {
    }
}
