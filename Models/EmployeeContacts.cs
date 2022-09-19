using DemoApplication.WebAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApplication.WebAPI.Models
{
    [Index(nameof(Type))]
    [Index(nameof(Value))]
    [Index(nameof(IsActive))]
    [Index(nameof(IsPrimary))]
    public class EmployeeContacts : BaseEntity
    {
        public EmployeeContactTypes EmployeeContactType { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
