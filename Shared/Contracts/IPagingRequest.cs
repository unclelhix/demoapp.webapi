namespace DemoApplication.WebAPI.Shared.Contracts
{
    public interface IPagingRequest
    {
        int CurrentPage { get; set; }
        int ItemsPerPage { get; set; }
    }
}
