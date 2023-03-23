using Newtonsoft.Json;
using System.Net;
using TodoListSPA.Entities.Errors;

namespace TodoListSPA.Helpers;

public class ErrorHandlerMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
    {
        _logger = loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                AppException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            _logger.LogError("{path} : {message}", context.Request?.Path, error!.Message);
            string result = JsonConvert.SerializeObject(new ErrorModel(response.StatusCode, error?.Message));
            await response.WriteAsync(result);
        }
    }
}
