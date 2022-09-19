using DemoApplication.WebAPI.CustomMapper;
using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Services.ObjectMapping;
using DemoApplication.WebAPI.Transports;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeMappingService _employeeMappingService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICustomMapper _customMapper;

        public EmployeeService(
            ApplicationDbContext applicationDbContext, 
            ICustomMapper customMapper, 
            IEmployeeMappingService employeeMappingService)
        {
            _applicationDbContext = applicationDbContext;
            _employeeMappingService = employeeMappingService;
            _customMapper = customMapper;
        }

        public async Task<bool> Add(EmployeeTransport transportEntity)
        {
            var employee = _employeeMappingService.MapToEmployee(transportEntity);

            await _applicationDbContext.Employee.AddAsync(employee);

            bool result = await _applicationDbContext.SaveChangesAsync() > 0 ? true: false;

            return result;

        }

        public async Task<EmployeeTransport> GetById(long id)
        {
            var employee = await _applicationDbContext.Employee
                .Include(x => x.EmployeeContacts)
                .Include(x => x.EmployeeGovernmentNumbers)
                .Where(e => e.Id == id).FirstOrDefaultAsync();

            var result = _customMapper.Map<Employee, EmployeeTransport>(employee);

            //var result = _employeeMappingService.MapToEmployeeTransport(employee);

            return result;
        }

        public async Task<IEnumerable<EmployeeTransport>> GetAll()
        {
            var employee = await _applicationDbContext.Employee
                .Include(x => x.EmployeeContacts)
                .Include(x => x.EmployeeGovernmentNumbers)
                .ToListAsync();

            var result = _employeeMappingService.MapToEmployeeTransport(employee);

            return result;
        }

        public async Task<bool> Update(EmployeeTransport transportEntity)
        {
            var employee = _applicationDbContext.Employee
               .Include(x => x.EmployeeContacts)
               .Include(x => x.EmployeeGovernmentNumbers)
               .Where(e => e.Id == transportEntity.Id).FirstOrDefault();

            employee.UpdatedOn = DateTime.Now;
            employee.UpdatedBy = "User";

            employee = _employeeMappingService.MapToEmployee(transportEntity, employee);


            bool result = await _applicationDbContext.SaveChangesAsync() > 0 ? true : false;

            return result;
        }

        public async Task<List<EmployeeTransport>> GetBySearchTerm(string searchTerm)
        {
            var employee = await _applicationDbContext.Employee
                .Include(x => x.EmployeeContacts)
                .Include(x => x.EmployeeGovernmentNumbers)
                .Where(e =>
                EF.Functions.Like(e.FirstName, searchTerm) ||
                EF.Functions.Like(e.LastName, searchTerm) ||
                EF.Functions.Like(e.EmployeeNumber, searchTerm))
                .ToListAsync();

            var result = _employeeMappingService.MapToEmployeeTransport(employee);

            return result;

        }

       


        //public EmployeeTransport Get(long id)
        //{
        //    return _applicationDbContext.Employee.Where(x => x.Id == id).FirstOrDefault();
        //}

        //public IEnumerable<EmployeeTransport> GetAll()
        //{
        //    return _applicationDbContext.Employee.ToList();
        //}

        //public EmployeeTransport GetByName(string name)
        //{
        //    return _applicationDbContext.Employee.Where(x => x.FirstName == name).FirstOrDefault();
        //}

        //public void Update(EmployeeTransport entity)
        //{
        //    if (entity.Id != 0 || entity.Id != null)
        //    {

        //        var modifiedDate = DateTime.Now;

        //        var dbEntity = _applicationDbContext.Employee.Where(x => x.Id == entity.Id).FirstOrDefault();

        //        dbEntity.FirstName = entity.FirstName;
        //        dbEntity.LastName = entity.LastName;
        //        dbEntity.MiddleName = entity.MiddleName;
        //        dbEntity.BirthDate = entity.BirthDate;
        //        dbEntity.UpdatedOn = modifiedDate;
        //        dbEntity.UpdatedBy = "User";
        //        dbEntity.EmployeeStatus = entity.EmployeeStatus;

        //        _applicationDbContext.SaveChanges();

        //    }


        //}



    }
}
