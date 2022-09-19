using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Shared.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.DatabaseContext
{
    public interface IApplicationDbContext : IDbContext
    {
        DbSet<Department> Department { get; set; }
        DbSet<DepartmentGroup> DepartmentGroup { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<EmployeeContacts> EmployeeContacts { get; set; }
        DbSet<EmployeeGovernmentNumbers> EmployeeGovernmentNumbers { get; set; }

    }
}
