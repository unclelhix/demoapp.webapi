using DemoApplication.WebAPI.Shared.Attributes;

namespace DemoApplication.WebAPI.Transports
{
    public abstract class BaseTransport
    {    
        public long? Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
