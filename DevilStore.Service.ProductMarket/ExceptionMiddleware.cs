using DevilStore.Service.ProductMarket.Model;
using System.Net;
using System.Text.Json;

namespace DevilStore.Service.ProductMarket
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (InvalidDataException dataException)
            {
                await HandleExceptionAsync(logger, dataException, httpContext, HttpStatusCode.BadRequest, dataException.Message);
            }
            catch (UnauthorizedAccessException invalidCredentialsException)
            {
                await HandleExceptionAsync(logger, invalidCredentialsException, httpContext, HttpStatusCode.Unauthorized, invalidCredentialsException.Message);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(
                    logger,
                    exception,
                    httpContext,
                    HttpStatusCode.InternalServerError,
                    exception.Message);
            }
        }

        private static Task HandleExceptionAsync(
            ILogger<ExceptionMiddleware> logger,
            Exception ex,
            HttpContext context,
            HttpStatusCode statusCode,
            string message = null)
        {
            logger.LogError("Exception occurred", ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var errorModel = new ErrorModel
            {
                statusCode = context.Response.StatusCode,
                errorMessage = message
            };

            var errorModelJson = JsonSerializer.Serialize(errorModel);

            return context.Response.WriteAsync(errorModelJson);
        }
    }
}
