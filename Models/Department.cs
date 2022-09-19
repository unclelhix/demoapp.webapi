using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication.WebAPI.Models
{
    public class Department : BaseCode
    {
        public Department()
        {         
            DepartmentGroup = new HashSet<DepartmentGroup>();
        }
        public virtual ICollection<DepartmentGroup> DepartmentGroup { get; set; }

    }
}
