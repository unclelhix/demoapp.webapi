using DemoApplication.WebAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication.WebAPI.Models
{
    [Index(nameof(FirstName))]
    [Index(nameof(LastName))]
    [Index(nameof(EmployeeNumber))]
    public class Employee : BaseEntity
    {
        public Employee()
        {
            EmployeeContacts = new HashSet<EmployeeContacts>();
            EmployeeGovernmentNumbers = new HashSet<EmployeeGovernmentNumbers>();
        }
        public EmployeeStatus EmployeeStatus { get; set; }
        public EmployeeSkillStatus EmployeeSkillStatus { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public long DepartmentGroupId { get; set; }

        [ForeignKey("DepartmentGroupId")]
        public virtual DepartmentGroup DepartmentGroup { get; set; }
        public virtual ICollection<EmployeeContacts> EmployeeContacts { get; set; }
    
        public virtual ICollection<EmployeeGovernmentNumbers> EmployeeGovernmentNumbers { get; set; }

    }
}
