using System.Collections;
using System.Collections.Generic;
using AvaloniaApplication1.Models;


namespace AvaloniaApplication1.Service;

public interface IStorageService
{
    void SaveTasks(IList tasksList);
    IList<TaskDTO> LoadTasks();
}