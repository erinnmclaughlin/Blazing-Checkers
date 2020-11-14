using System.Collections.Generic;

namespace BlazingCheckers.Shared.Contracts
{
    public class ApiPagedResponse<T> : BaseApiResponse, IApiListResponse<T>
    {
        public ApiPagedResponse() { }
        public ApiPagedResponse(IEnumerable<T> data, int pageNumber, int pageSize, int maxPageNumber)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            MaximumPageNumber = maxPageNumber;
        }

        public IEnumerable<T> Data { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int MaximumPageNumber { get; set; }
    }
}