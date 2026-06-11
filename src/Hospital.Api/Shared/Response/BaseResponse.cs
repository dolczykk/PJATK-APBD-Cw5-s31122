namespace Hospital.Api.Shared.Response;

public record BaseResponse(object? Data, string? ErrorMessage, bool IsError = false)
{
    public static BaseResponse Success(object? data)
    {
        return new BaseResponse(data, null);
    }

    public static BaseResponse Error(string errorMessage)
    {
        return new BaseResponse(null, errorMessage, true);
    }
}