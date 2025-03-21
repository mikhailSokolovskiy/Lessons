using Microsoft.Extensions.DependencyInjection;

namespace Lesson_DependencyInjection.Services;

public interface ILogger
{
    void Log(string msg);
}