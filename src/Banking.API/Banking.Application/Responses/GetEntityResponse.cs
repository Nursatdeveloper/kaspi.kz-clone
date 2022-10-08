namespace Banking.Application.Responses
{
    public class GetEntityResponse<T> where T : class
    {
        public T? Entity { get; set; }
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
