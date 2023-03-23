using System.Net;

namespace TodoListSPA.Entities.Errors;

public class ErrorModel
{
    public ErrorModel(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }

    public ErrorModel(int statusCode, string? message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public ErrorModel(string? message)
        : this()
    {
        Message = message;
    }

    public ErrorModel()
    {
        StatusCode = 500;
    }

    public int StatusCode { get; set; }
    public string? Message { get; set; }
}
