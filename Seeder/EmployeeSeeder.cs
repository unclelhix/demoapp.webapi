using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Shared;

namespace DemoApplication.WebAPI.Seeder
{
    public class EmployeeSeeder : BaseMigration, IEmployeeSeeder
    {
        public EmployeeSeeder(ApplicationDbContext applicationDbContext, string migrationIdentifierKey) : base(applicationDbContext, migrationIdentifierKey)
        {
        }

        protected override async Task ProcessMigration()
        {
            await InitialMigration();
        }

        private async Task InitialMigration()
        {
            var date = DateTime.Now;
            if (!(await TryAddMigration()))
            {
                return;
            }

            await this.ApplicationDbContext.Employee.AddRangeAsync(

                new Employee()
                {
                    EmployeeNumber = "EMP-000001",
                    EmployeeStatus = Models.Enums.EmployeeStatus.Regular,
                    FirstName = "Demo",
                    LastName = "User",
                    CreatedBy = "System",
                    CreatedOn = date,
                    UpdatedBy = "System",
                    UpdatedOn = date,
                    BirthDate = date.AddYears(-20),
                    EmployeeContacts = new List<EmployeeContacts> { new EmployeeContacts {
                         IsActive = true,
                         Type = "Email",
                         Value =  "demo@gamil.com",
                         EmployeeContactType = Models.Enums.EmployeeContactTypes.Email,
                        CreatedBy = "System",
                        CreatedOn = date,
                        UpdatedBy = "System",
                        UpdatedOn = date,
                        IsPrimary = true

                    },
                    new EmployeeContacts {
                         IsActive = true,
                         Type = "Email",
                         Value =  "demotest@gamil.com",
                         EmployeeContactType = Models.Enums.EmployeeContactTypes.Email,
                        CreatedBy = "System",
                        CreatedOn = date,
                        UpdatedBy = "System",
                        UpdatedOn = date,
                        IsPrimary = false

                    }},
                    EmployeeGovernmentNumbers = new List<EmployeeGovernmentNumbers> { new EmployeeGovernmentNumbers {
                         GovernmentNumberTypeId = Models.Enums.GovernmentNumberType.SSS,
                         Type = Models.Enums.GovernmentNumberType.SSS.ToString(),
                         Value  = "123-123-12345",
                         CreatedBy = "System",
                         CreatedOn = date,
                         UpdatedBy = "System",
                         UpdatedOn = date


                    },
                    new EmployeeGovernmentNumbers {
                         GovernmentNumberTypeId = Models.Enums.GovernmentNumberType.TIN,
                         Type = Models.Enums.GovernmentNumberType.TIN.ToString(),
                         Value  = "22-222-22222",
                         CreatedBy = "System",
                         CreatedOn = date,
                         UpdatedBy = "System",
                         UpdatedOn = date

                    }}

                }
            );
        }

       
    }
}
