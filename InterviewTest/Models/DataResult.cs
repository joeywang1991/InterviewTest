using Microsoft.AspNetCore.Http;

namespace InterviewTest.Models
{
    public class DataResult<T>
    {
        public bool IsSuccess { get; set; }

        public T Data { get; set; }

        public int StatusCode { get; set; }

        public string? ErrorMessage { get; set; }

        public void SetSuccess(T data)
        {
            IsSuccess = true;
            StatusCode = 1;
            Data = data;
        }

        public void SetError(string message = "", int statusCode = 9999)
        {
            IsSuccess = false;
            StatusCode = statusCode;
            ErrorMessage = message;
        }
    }

    public class DataResult
    {
        public bool IsSuccess { get; set; }

        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }


        public void SetSuccess()
        {
            IsSuccess = true;
            StatusCode = 1;
        }

        public void SetError(string message = "", int statusCode = 9999)
        {
            IsSuccess = false;
            StatusCode = statusCode;
            ErrorMessage = message;
        }
    }
}
