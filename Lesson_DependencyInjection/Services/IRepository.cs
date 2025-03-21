namespace Lesson_DependencyInjection.Services;

public interface IRepository
{
    public string GetAllStrings();
    
    public void AddString(string value);
}