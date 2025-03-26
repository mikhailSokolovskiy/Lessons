using System.Collections.Generic;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service.Realizations;

public class TaskService : ITaskService
{
    private List<TaskDTO> _tasks;

    public TaskService(ILoggerService logger)
    {
        _tasks = new List<TaskDTO>();
    }

    public void AddRangeTasks(IList<TaskDTO> taskList)
    {
        _tasks.AddRange(taskList);
    }

    public void AddTask(TaskDTO taskDto)
    {
        _tasks.Add(taskDto);
    }

    public void EditTask(TaskDTO taskDto)
    {
        // var oldTask = _tasks.First(task => task.Id == taskDto.Id);
        // var index = _tasks.IndexOf(oldTask);
        // _tasks[index] = taskDto;
    }

    public void DeleteTask(TaskDTO taskDto)
    {
       // var oldTask = _tasks.First(task => task.Id == taskDto.Id);
       // _tasks.Remove(oldTask);
    }
}