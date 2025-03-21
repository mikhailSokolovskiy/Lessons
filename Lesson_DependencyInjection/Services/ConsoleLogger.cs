using System;

namespace Lesson_DependencyInjection.Services;

public class ConsoleLogger : ILogger
{
    public void Log(string msg)
    {
        Console.WriteLine($"[LOG]: {msg}");
    }
}