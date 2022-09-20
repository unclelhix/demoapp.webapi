using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Shared.Contracts;
using DemoApplication.WebAPI.Shared.Responses;
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
        public async Task<ServiceResponse<bool>> Add(DepartmentGroupTransport transportEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagingResponse<DepartmentGroupTransport>> GetAll(PagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<IEnumerable<DepartmentGroupTransport>>> GetByDepartmentId(long departmentId)
        {
            var departmentGroup = await _dbContext.DepartmentGroup
                .Where(x => x.DepartmentId == departmentId)
                .ProjectToType<DepartmentGroupTransport>()
                .ToListAsync();

            return new ServiceResponse<IEnumerable<DepartmentGroupTransport>>
            {
                Data = departmentGroup
            };
        }

        public async Task<ServiceResponse<DepartmentGroupTransport>> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> Update(DepartmentGroupTransport transportEntity)
        {
            throw new NotImplementedException();
        }
    }
}
