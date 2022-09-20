using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Shared.Responses;
using DemoApplication.WebAPI.Transports;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<bool>> Add(EmployeeTransport transportEntity)
        {
            var employee = _mapper.Map<Employee>(transportEntity);

            await _dbContext.Employee.AddAsync(employee);

            return new ServiceResponse<bool>
            {
                Data = (await _dbContext.SaveChangesAsync() > 0 ? true : false)
            };
        }

        public async Task<PagingResponse<EmployeeTransport>> GetAll(PagingRequest request)
        {
            var query = _dbContext.Employee;

            var items = await query.Skip(request.SkipItems).Take(request.ItemsPerPage).ToListAsync();

            var totalItems = await query.CountAsync();

            var mappedItems = _mapper.Map<List<EmployeeTransport>>(items);

            return new PagingResponse<EmployeeTransport>
            {
                Data = mappedItems,
                TotalItems = totalItems,
                CurrentPage = request.CurrentPage,
                ItemsPerPage = request.ItemsPerPage

            };
        }

        public async Task<ServiceResponse<EmployeeTransport>> GetById(long id)
        {
            var employee = await _dbContext.Employee.Where(x => x.Id == id)
                .ProjectToType<EmployeeTransport>()
                .FirstOrDefaultAsync();

            //var result = _mapper.Map<DepartmentTransport>(department);

            return new ServiceResponse<EmployeeTransport>
            {
                Data = employee
            };
        }

        public async Task<ServiceResponse<bool>> Update(EmployeeTransport transportEntity)
        {
            var employee = await _dbContext.Employee.Where(x => x.Id == transportEntity.Id).FirstOrDefaultAsync();

            transportEntity.Adapt(employee);

            return new ServiceResponse<bool>
            {
                Data = (await _dbContext.SaveChangesAsync() > 0 ? true : false)
            };
        }
    }
}
