using Microsoft.AspNetCore.Diagnostics;

namespace Global_exception_Handling
{
    public class AppNotImplementedExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var response = new ErrorResponse()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ExceptionMessage = exception.Message,
                Title = "Something went wrong"
            };
        
          // httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            
             await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);


            return true;

        }
    }
}
