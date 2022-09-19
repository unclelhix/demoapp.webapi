using DemoApplication.WebAPI.Shared.Contracts;

namespace DemoApplication.WebAPI.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
