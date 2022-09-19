using DemoApplication.WebAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApplication.WebAPI.Models
{
    [Index(nameof(Type))]
    [Index(nameof(Value))]
    public class EmployeeGovernmentNumbers : BaseEntity
    {
        public GovernmentNumberType GovernmentNumberTypeId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

    }
}
