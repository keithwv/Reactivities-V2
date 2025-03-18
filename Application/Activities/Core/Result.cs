namespace Application.Activities.Core;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T? Value { get; set; }
    public string? Error { get; set; }
    public int Code { get; set; }

    public static Result<T> CreateSuccess(T value) => new()
    {
        IsSuccess = true,
        Value = value,
    };

    public static Result<T> Failure(string error, int code) => new()
    {
        IsSuccess = false,
        Error = error,
        Code = code,
    };
}