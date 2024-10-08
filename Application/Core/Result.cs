namespace Application.Core
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; } = string.Empty;
        public int StatusCode { get; set; }

        public static Result<T> Success(T value) =>
            new Result<T> { IsSuccess = true, Value = value, StatusCode = 200 };
        public static Result<T> Failure(string error) =>
            new Result<T> { IsSuccess = false, Error = error, StatusCode = 500 };
    }
}