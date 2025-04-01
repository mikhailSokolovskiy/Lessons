using System.Collections;
using System.Collections.Generic;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service;

public interface ITaskService
{
    IList<TaskDTO> AddRangeTasks(IList<TaskDTO> taskList);
    TaskDTO AddTask(TaskDTO taskDto);
    void EditTask(TaskDTO taskDto);
    void DeleteTask(TaskDTO taskDto);
    TaskDTO GetTaskByName(string taskName);
    IList<TaskDTO> GetAllTasks();
}