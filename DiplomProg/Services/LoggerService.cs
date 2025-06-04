using System;
using Serilog;

namespace DiplomProg.Services;

public static class LoggerService
{
    public static void InitializeLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File("logs/service-center-.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    public static void LogInformation(string message) => Log.Information(message);
    public static void LogError(string message, Exception? ex = null) =>
        Log.Error(ex, message);
}
