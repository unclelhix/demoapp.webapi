using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Shared.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.DatabaseSeeder
{
    public class DepartmentSeeder : ISeeder
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IDateTimeService _date;
        public DepartmentSeeder(ApplicationDbContext dbcontext, IDateTimeService date)
        {
            _dbcontext = dbcontext;
            _date = date;
        }
        public void Seed()
        {
            if (!_dbcontext.Department.Any()) {

                var department = new List<Department>()
                {
                    new Department(){
                         Description = "Information Technology",
                         Code = "IT",
                         CreatedBy = "System",
                         CreatedOn = _date.Now,
                         UpdatedBy = "System",
                         UpdatedOn = _date.Now,
                         DepartmentGroup = new List<DepartmentGroup>(){
                             new DepartmentGroup(){
                                 Description = "DevOps",
                                 Code = "DV",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Development Team Lead",
                                 Code = "DTL",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Business Analyst",
                                 Code = "BA",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },                             
                             new DepartmentGroup(){
                                 Description = "Sofware Engineer",
                                 Code = "SE",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Quality Assurance",
                                 Code = "QA",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             }
                         }
                     },                    
                    new Department(){
                         Description = "Marketing",
                         Code = "MKT",
                         CreatedBy = "System",
                         CreatedOn = _date.Now,
                         UpdatedBy = "System",
                         UpdatedOn = _date.Now,
                         DepartmentGroup = new List<DepartmentGroup>(){
                             new DepartmentGroup(){
                                 Description = "Digital",
                                 Code = "DT",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Ecommerce",
                                 Code = "ECOMT",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Production",
                                 Code = "PROD",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Graphic Artist",
                                 Code = "GRAPHICS",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             }
                         }
                     },
                    new Department(){ 
                         Description = "Accounting",
                         Code = "ACC",
                         CreatedBy = "System",
                         CreatedOn = _date.Now,
                         UpdatedBy = "System",
                         UpdatedOn = _date.Now,
                         DepartmentGroup = new List<DepartmentGroup>(){
                             new DepartmentGroup(){
                                 Description = "Assistant",
                                 Code = "AST",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Bookkeeper",
                                 Code = "BK",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Expense",
                                 Code = "EXP",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             },
                             new DepartmentGroup(){
                                 Description = "Encoder",
                                 Code = "ENC",
                                 CreatedBy = "System",
                                 CreatedOn = _date.Now,
                                 UpdatedBy = "System",
                                 UpdatedOn = _date.Now,
                             }
                         }
                     }
                };

                this._dbcontext.Department.AddRange(department);

                this._dbcontext.SaveChanges();
            }
        }
    }
}
