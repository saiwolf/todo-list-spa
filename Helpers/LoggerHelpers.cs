using System.Runtime.CompilerServices;

namespace TodoListSPA.Helpers;

public static class LoggerHelpers
{
    public static void Error(this ILogger logger, string exMessage,
        [CallerFilePath] string? filePath = "",
        [CallerMemberName] string? memberName = "",
        params object[] args) =>
        logger.Log(LogLevel.Error, exMessage, filePath!, memberName!, args);
    public static void Warning(this ILogger logger, string exMessage,
        [CallerFilePath] string? filePath = "",
        [CallerMemberName] string? memberName = "",
        params object[] args) =>
        logger.Log(LogLevel.Warning, exMessage, filePath!, memberName!, args);
    public static void Info(this ILogger logger, string exMessage,
        [CallerFilePath] string? filePath = "",
        [CallerMemberName] string? memberName = "",
        params object[] args) =>
        logger.Log(LogLevel.Information, exMessage, filePath!, memberName!, args);
    public static void Debug(this ILogger logger, string exMessage,
        [CallerFilePath] string? filePath = "",
        [CallerMemberName] string? memberName = "",
        params object[] args) =>
        logger.Log(LogLevel.Debug, exMessage, filePath!, memberName!, args);

    private static void Log(
        this ILogger logger,
        LogLevel level,
        string exMessage,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string methodName = "",
        params object[] args)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.GetRelativePath(baseDir, filePath);
        fullPath = fullPath.Replace("..\\", "");
        fullPath = fullPath.Replace("\\", "/");
        string output = $"~/{fullPath} - [{methodName}]: {exMessage}";
        logger.Log(level, output, args);
    }
}
