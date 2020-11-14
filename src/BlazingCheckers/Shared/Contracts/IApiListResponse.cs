using System.Collections.Generic;

namespace BlazingCheckers.Shared.Contracts
{
    public interface IApiListResponse<T>
    {
        bool Success { get; set; }
        List<string> ErrorMessages { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}