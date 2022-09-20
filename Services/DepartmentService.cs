using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Shared.Responses;
using DemoApplication.WebAPI.Transports;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext; 
            _mapper = mapper;
        }
        public async Task<ServiceResponse<bool>> Add(DepartmentTransport transportEntity)
        {
            var department = _mapper.Map<Department>(transportEntity);

            await _dbContext.Department.AddAsync(department);

            return new ServiceResponse<bool>
            {
                Data = (await _dbContext.SaveChangesAsync() > 0 ? true : false)
            };

        }

        public async Task<PagingResponse<DepartmentTransport>> GetAll(PagingRequest request)
        {
            var query = _dbContext.Department;

            var items = await query.Skip(request.SkipItems).Take(request.ItemsPerPage).ToListAsync();

            var totalItems = await query.CountAsync();

            var mappedItems = _mapper.Map<List<DepartmentTransport>>(items);

            return new PagingResponse<DepartmentTransport>
            {
                Data = mappedItems,
                TotalItems = totalItems,
                CurrentPage = request.CurrentPage,
                ItemsPerPage = request.ItemsPerPage
             
            };
        }

        public async Task<ServiceResponse<List<DepartmentTransport>>> GetAllDepartment()
        {
            var departments = await _dbContext.Department
               .ProjectToType<DepartmentTransport>()
               .ToListAsync();


            return new ServiceResponse<List<DepartmentTransport>>
            {
                Data = departments
            };
        }

        public async Task<ServiceResponse<DepartmentTransport>> GetById(long id)
        {
            var department = await _dbContext.Department.Where(x => x.Id == id)
                .ProjectToType<DepartmentTransport>()
                .FirstOrDefaultAsync();

            //var result = _mapper.Map<DepartmentTransport>(department);

            return new ServiceResponse<DepartmentTransport>
            {
                Data = department
            };
        }

        public async Task<ServiceResponse<bool>> Update(DepartmentTransport transportEntity)
        {
            var department = await _dbContext.Department.Where(x => x.Id == transportEntity.Id).FirstOrDefaultAsync();

            transportEntity.Adapt(department);

            return new ServiceResponse<bool> {
                Data = (await _dbContext.SaveChangesAsync() > 0 ? true : false)
            };
        }
    }
}
