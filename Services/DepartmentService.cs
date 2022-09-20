using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
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
        public async Task<bool> Add(DepartmentTransport transportEntity)
        {
            var department = _mapper.Map<Department>(transportEntity);

            await _dbContext.Department.AddAsync(department);

            return (await _dbContext.SaveChangesAsync() > 0 ? true : false);

        }

        public async Task<IEnumerable<DepartmentTransport>> GetAll()
        {
            var departments = await _dbContext.Department.ProjectToType<DepartmentTransport>().ToListAsync();        

            return departments;
        }

        public async Task<DepartmentTransport> GetById(long id)
        {
            var department = await _dbContext.Department.Where(x => x.Id == id).FirstOrDefaultAsync();

            var result = _mapper.Map<DepartmentTransport>(department);

            return result;
        }

        public async Task<bool> Update(DepartmentTransport transportEntity)
        {
            var department = await _dbContext.Department.Where(x => x.Id == transportEntity.Id).FirstOrDefaultAsync();

            transportEntity.Adapt(department);

            return (await _dbContext.SaveChangesAsync() > 0 ? true : false);
        }
    }
}
