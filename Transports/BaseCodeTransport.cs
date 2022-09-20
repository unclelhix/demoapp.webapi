namespace DemoApplication.WebAPI.Transports
{
    public abstract class BaseCodeTransport : BaseTransport
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
