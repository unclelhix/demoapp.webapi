using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public interface IDepartmentService : IBaseDataRepository<DepartmentTransport>
    {
    }
}
