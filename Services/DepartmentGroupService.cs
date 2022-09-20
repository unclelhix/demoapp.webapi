using DemoApplication.WebAPI.Transports;

namespace DemoApplication.WebAPI.Services
{
    public class DepartmentGroupService : IDepartmentGroupService
    {
        public DepartmentGroupService()
        {

        }
        public async Task<bool> Add(DepartmentGroupTransport transportEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DepartmentGroupTransport>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DepartmentGroupTransport> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(DepartmentGroupTransport transportEntity)
        {
            throw new NotImplementedException();
        }
    }
}
