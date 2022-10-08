namespace Banking.Application.Responses
{
    public class CreatedResponse<T> where T : class
    {
        public int Id { get; set; }
        public T? Entity { get; set; }
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
