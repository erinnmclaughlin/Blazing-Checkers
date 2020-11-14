using System.Collections.Generic;

namespace BlazingCheckers.Shared.Contracts
{
    public class ApiListResponse<T> : BaseApiResponse, IApiListResponse<T>
    {
        public ApiListResponse() { }
        public ApiListResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
    }
}
