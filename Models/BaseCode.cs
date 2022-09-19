using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.Models
{
    [Index("Code")]
    [Index("Description")]
    public abstract class BaseCode : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
