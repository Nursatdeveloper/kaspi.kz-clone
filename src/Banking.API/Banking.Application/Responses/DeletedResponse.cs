namespace Banking.Application.Responses
{
    public class DeletedResponse
    {
        public bool IsDeletedSuccessfully { get; set; }
        public string Message { get; set; }
        public DeletedResponse(bool isDeleted, string message)
        {
            IsDeletedSuccessfully = isDeleted;
            Message = message;
        }

    }
}
