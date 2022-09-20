using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public interface IEmployeeService_old : IBaseDataRepository<EmployeeTransport>
    {
        Task<List<EmployeeTransport>> GetBySearchTerm(string searchTerm);
    }
}
