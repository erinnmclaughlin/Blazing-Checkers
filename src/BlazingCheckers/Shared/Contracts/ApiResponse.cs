namespace BlazingCheckers.Shared.Contracts
{
    public class ApiResponse<T> : BaseApiResponse
    {
        public ApiResponse() { }
        public ApiResponse(T response)
        {
            Data = response;
        }
        
        public T Data { get; set; }
    }
}