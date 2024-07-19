using UnityEngine;

public static class DebugExtensions
{
    public static void Log(this ErrorType errorType)
    {
        ErrorHandler.LogError(errorType);
    }

    public static void LogCustomError(this ErrorType errorType, string message)
    {
        ErrorHandler.LogCustomError(errorType, message);
    }
}
