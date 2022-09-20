using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public interface IDepartmentGroupService : IBaseDataRepository<DepartmentGroupTransport>
    {
        Task<IEnumerable<DepartmentGroupTransport>> GetByDepartmentId(long departmentId);
    }
}
