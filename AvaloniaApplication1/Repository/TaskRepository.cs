using System;
using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.DB;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Repository;

public class TaskRepository : IRepository<TaskDTO>
{
    private readonly ApplicationContext _context;

    public TaskRepository(ApplicationContext context)
    {
        _context = context;
    }

    public TaskDTO GetById(int id)
    {
        return _context.Tasks.First(x => x.Id == id);
    }

    public IList<TaskDTO> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public TaskDTO Add(TaskDTO entity)
    {
       var task = _context.Tasks.Add(entity);
       _context.SaveChanges();
       return task.Entity;
    }

    public void Update(TaskDTO entity)
    {
        _context.Tasks.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(TaskDTO entity)
    {
        _context.Tasks.Remove(entity);
        _context.SaveChanges();
    }
}