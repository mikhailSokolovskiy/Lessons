using System.Collections;
using System.Collections.Generic;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service;

public interface ITaskService
{
    void AddRangeTasks(IList<TaskDTO> taskList);
    void AddTask(TaskDTO taskDto);
    void EditTask(TaskDTO taskDto);
    void DeleteTask(TaskDTO taskDto);
}