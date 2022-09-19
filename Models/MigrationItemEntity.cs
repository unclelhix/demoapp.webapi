using Microsoft.EntityFrameworkCore;

namespace DemoApplication.WebAPI.Models
{
    /// <summary>
    /// This will be the Migration Item
    /// </summary>
    [Index(nameof(MigrationKey), IsUnique = true)]
    public class MigrationItemEntity : BaseEntity
    {
        public string MigrationKey { get; set; }
    }
}
