using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Repository;

namespace AvaloniaApplication1.Service.Realizations;

public class TaskService : ITaskService
{
    private IRepository<TaskDTO> _repository;
    private readonly ILoggerService _logger;

    public TaskService(ILoggerService logger, IRepository<TaskDTO> repository)
    {
        _repository = repository;
        _logger = logger;
    }

    public IList<TaskDTO> AddRangeTasks(IList<TaskDTO> taskList)
    {
        var tasks = _repository.GetAll();
        foreach (var task in taskList)
        {
            if (!tasks.Contains(task))
                tasks.Add(AddTask(task));
            else
                EditTask(task);
        }
        return tasks;
    }

    public TaskDTO AddTask(TaskDTO taskDto)
    {
        if (ValidateTask(taskDto.TaskName))
            return _repository.Add(taskDto);
        else
        {
            _logger.Log("Invalid task name");
            throw new NotImplementedException();
        }
    }

    public void EditTask(TaskDTO taskDto)
    {
        _repository.Update(taskDto);
    }

    public void DeleteTask(TaskDTO taskDto)
    {
        _repository.Delete(taskDto);
    }

    public TaskDTO GetTaskByName(string taskName)
    {
        var allTasks = _repository.GetAll();
        return allTasks.First(x => x.TaskName == taskName);
    }

    public IList<TaskDTO> GetAllTasks()
    {
        return _repository.GetAll();
    }

    private bool ValidateTask(string taskName)
    {
        return taskName != string.Empty;
    }
}