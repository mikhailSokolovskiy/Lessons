using System;
using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.DB;
using AvaloniaApplication1.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApplication1.Service.Realizations;

public class TaskStorageService : IStorageService<TaskDTO>
{
    public void Save(IList<TaskDTO> tasksList)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            foreach (var el in tasksList) db.Tasks.Update(el);

            db.SaveChanges();
        }
    }

    public IList<TaskDTO> Load()
    {
        List<TaskDTO> tasksList;
        using (ApplicationContext db = new ApplicationContext())
        {
            tasksList = new List<TaskDTO>(db.Tasks.ToList());
        }
        return tasksList;
    }
}