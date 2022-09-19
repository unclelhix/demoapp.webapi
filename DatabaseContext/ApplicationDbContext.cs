using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoApplication.WebAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTimeService _dateTime;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeContacts> EmployeeContacts { get; set; }
        public DbSet<EmployeeGovernmentNumbers> EmployeeGovernmentNumbers { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DepartmentGroup> DepartmentGroup { get; set; }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return Database.BeginTransactionAsync(cancellationToken);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity &&
             (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(x => x.Entity as BaseEntity);

            await UpdateEntries(entries);

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected async Task UpdateEntries(IEnumerable<BaseEntity> entries)
        {
            await Task.Delay(10);

            var username = "system";

            foreach (var entry in entries)
            {
                if (entry.Id == default || string.IsNullOrEmpty(entry.CreatedBy))
                {
                    entry.CreatedOn = _dateTime.Now;
                    entry.CreatedBy = username;
                }
                entry.UpdatedOn = _dateTime.Now;
                entry.UpdatedBy = username;
            }

        }

    }
}



