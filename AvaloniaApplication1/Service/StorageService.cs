using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.DB;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Service;

public class StorageService : IStorageService
{
    public void SaveTasks(IList<TaskDTO> tasksList)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            foreach (var el in tasksList) db.Tasks.Update(el);

            db.SaveChanges();
        }
    }

    public IList<TaskDTO> LoadTasks()
    {
        List<TaskDTO> tasksList;
        using (ApplicationContext db = new ApplicationContext())
        {
            tasksList = new List<TaskDTO>(db.Tasks.ToList());
        }
        return tasksList;
    }
}