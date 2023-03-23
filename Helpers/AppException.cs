using System.Globalization;

namespace TodoListSPA;

/// <summary>
/// <para>
/// Source: 
/// <see href="https://jasonwatmore.com/post/2022/01/24/net-6-jwt-authentication-with-refresh-tokens-tutorial-with-example-api#app-exception-cs">
/// Jason Watmore's Blog - .NET 6.0 - JWT Authentication with Refresh Tokens Tutorial with Example API
/// </see>
/// </para>
/// <para>
/// Custom exception class for throwing application specific exceptions
/// (e.g. for validation) that can be caught and handled within the application.
/// </para>
/// </summary>
public class AppException : Exception
{
    public AppException() : base() { }

    public AppException(string message): base(message) { }

    public AppException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    { }
}
