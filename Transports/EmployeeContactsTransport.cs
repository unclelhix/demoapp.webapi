namespace DemoApplication.WebAPI.Transports
{
    public class EmployeeContactsTransport : BaseTransport
    {
        public int EmployeeContactType { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public long EmployeeId { get; set; }
    }
}
