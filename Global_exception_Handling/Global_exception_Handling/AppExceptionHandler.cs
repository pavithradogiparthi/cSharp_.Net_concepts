using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace Global_exception_Handling
{
    public class AppExceptionHandler(ILogger<AppExceptionHandler>logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is NotImplementedException)
            {
                logger.LogError(exception,exception.Message);
                var response = new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ExceptionMessage = exception.Message,
                    Title = "Something went wrong"
                };
               
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
           

                return true;
            }
            return false;
        }
    }
}
