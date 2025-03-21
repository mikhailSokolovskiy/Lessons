using System;

namespace Lesson_DependencyInjection.Services;

public class TextFileReader : IReader
{
    public string Read(string path)
    {
        Console.WriteLine("Read file");
        return "";
    }
}
