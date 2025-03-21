using System;

namespace Lesson_DependencyInjection.Services;

public class FileRepository : IRepository
{
    public string GetAllStrings()
    {
        Console.WriteLine("From repo");
        return "";
    }

    public void AddString(string value)
    {
        Console.WriteLine("Add string");
    }
}