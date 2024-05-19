namespace InterviewTest.Models
{
    public class DataResult<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public string? ErrorMessage { get; set; }

        public void SetSuccess(T data)
        {
            Success = true;
            Data = data;
        }

        public void SetError(string message = null)
        {
            Success = false;
            ErrorMessage = message;
        }
    }
}
