using DemoApplication.WebAPI.Shared.Contracts;
using DemoApplication.WebAPI.Shared.Responses;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public interface IDepartmentGroupService : IBaseServiceDataRepository<DepartmentGroupTransport>
    {
        Task<ServiceResponse<IEnumerable<DepartmentGroupTransport>>> GetByDepartmentId(long departmentId);
    }
}
