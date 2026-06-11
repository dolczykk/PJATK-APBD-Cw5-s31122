using Hospital.Api.Shared.Exceptions;
using Hospital.Api.Shared.Response;

namespace Hospital.Api.Middlewares;

public class ApplicationExceptionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ApplicationBaseException e)
        {
            context.Response.StatusCode = (int)e.StatusCode;
            await context.Response.WriteAsJsonAsync(BaseResponse.Error(e.Message));
        }
    }
}