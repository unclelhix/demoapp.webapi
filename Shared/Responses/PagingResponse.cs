using DemoApplication.WebAPI.Shared.Contracts;

namespace DemoApplication.WebAPI.Shared.Responses
{
    public class PagingResponse<T> : ServiceResponse<IEnumerable<T>>, IPagingRequest
    {
        /// <summary>
        /// This is the max item per page
        /// </summary>
        /// <value></value>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// This specifies the request current page
        /// </summary>
        /// <value></value>
        public int CurrentPage { get; set; }
        /// <summary>
        /// This is the total count of items that can be retrieved from the storage
        /// </summary>
        /// <value></value>
        public int TotalItems { get; set; }
        /// <summary>
        /// This is the total pages that can be created by the same query
        /// </summary>
        /// <value></value>
        public int TotalPages
        {
            get
            {
                if (TotalItems <= 0)
                {
                    return 1;
                }

                return ((TotalItems - 1) / ItemsPerPage) + 1;
            }
        }
        
    }
}
