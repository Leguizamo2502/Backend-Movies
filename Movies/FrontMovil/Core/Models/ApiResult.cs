namespace FrontMovil.Core.Models;

public record ApiResult<T>(bool IsSuccess, T? Data, string? Message = null)
{
    public static ApiResult<T> Success(T data, string? message = null) => new(true, data, message);
    public static ApiResult<T> Failure(string? message = null) => new(false, default, message);
}
