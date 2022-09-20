using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Transports;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.Services
{
    public class DepartmentGroupService : IDepartmentGroupService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DepartmentGroupService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public async Task<IEnumerable<DepartmentGroupTransport>> GetByDepartmentId(long departmentId)
        {
            var departmentGroup = await _dbContext.DepartmentGroup
                .Where(x=>x.DepartmentId == departmentId)
                .ProjectToType<DepartmentGroupTransport>().ToListAsync();

            return departmentGroup;
        }

        public async Task<bool> Update(DepartmentGroupTransport transportEntity)
        {
            throw new NotImplementedException();
        }
    }
}
