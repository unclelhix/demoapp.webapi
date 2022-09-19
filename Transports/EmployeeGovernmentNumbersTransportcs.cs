namespace DemoApplication.WebAPI.Transports
{
    public class EmployeeGovernmentNumbersTransportcs : BaseTransport
    {
        public int GovernmentNumberTypeId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public long EmployeeId { get; set; }
    }
}
