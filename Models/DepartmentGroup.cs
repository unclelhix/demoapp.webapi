using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication.WebAPI.Models
{
    public class DepartmentGroup : BaseCode
    {
        public DepartmentGroup()
        {
            Employee = new HashSet<Employee>();
        }
        public long DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

    }
}
