using System.Collections.Generic;

namespace BlazingCheckers.Shared.Contracts
{
    public abstract class BaseApiResponse
    {
        public bool Success { get; set; } = true;
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}