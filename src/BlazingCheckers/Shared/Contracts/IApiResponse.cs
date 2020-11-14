using System.Collections.Generic;

namespace BlazingCheckers.Shared.Contracts
{
    public interface IApiResponse<T>
    {
        bool Success { get; set; }
        List<string> ErrorMessages { get; set; } 
        T Data { get; set; }
    }
}