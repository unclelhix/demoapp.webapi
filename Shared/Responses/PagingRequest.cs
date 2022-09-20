using DemoApplication.WebAPI.Shared.Contracts;
using System.Runtime.Serialization;

namespace DemoApplication.WebAPI.Shared.Responses
{
    public class PagingRequest : IPagingRequest
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        [IgnoreDataMember]
        public int SkipItems { get => CurrentPage <= 1 ? 0 : (CurrentPage - 1) * ItemsPerPage; }

    }
}
