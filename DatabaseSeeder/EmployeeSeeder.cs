using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;

namespace DemoApplication.WebAPI.DatabaseSeeder
{
    public class EmployeeSeeder : ISeeder
    {

        private readonly ApplicationDbContext _dbcontext;
        public EmployeeSeeder(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public void Seed()
        {
            var date = DateTime.Now;

            if (!_dbcontext.Employee.Any())
            {
                var employee = new List<Employee>() {

                new Employee()
                {                      

                    EmployeeNumber = "EMP-000001",
                    EmployeeStatus = Models.Enums.EmployeeStatus.Regular,
                    EmployeeSkillStatus = Models.Enums.EmployeeSkillStatus.Senior,      
                    DepartmentGroupId = 1,
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

                },
                new Employee()
                {

                    EmployeeNumber = "EMP-000002",
                    EmployeeStatus = Models.Enums.EmployeeStatus.Regular,
                    EmployeeSkillStatus = Models.Enums.EmployeeSkillStatus.Mid,
                    DepartmentGroupId = 2,
                    FirstName = "Demo 2",
                    LastName = "User 2",
                    CreatedBy = "System",
                    CreatedOn = date,
                    UpdatedBy = "System",
                    UpdatedOn = date,
                    BirthDate = date.AddYears(-15),
                    EmployeeContacts = new List<EmployeeContacts> { new EmployeeContacts {

                        IsActive = true,
                        Type = "Email",
                        Value =  "demo2@gamil.com",
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
                        Value =  "demotest2@gamil.com",
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
                         Value  = "123-123-34545",
                         CreatedBy = "System",
                         CreatedOn = date,
                         UpdatedBy = "System",
                         UpdatedOn = date
                    },
                    new EmployeeGovernmentNumbers {


                         GovernmentNumberTypeId = Models.Enums.GovernmentNumberType.TIN,
                         Type = Models.Enums.GovernmentNumberType.TIN.ToString(),
                         Value  = "22-222-23764",
                         CreatedBy = "System",
                         CreatedOn = date,
                         UpdatedBy = "System",
                         UpdatedOn = date

                    }}

                }
             };

                this._dbcontext.Employee.AddRange(employee);

                this._dbcontext.SaveChanges();
            }
        }
    }
}
