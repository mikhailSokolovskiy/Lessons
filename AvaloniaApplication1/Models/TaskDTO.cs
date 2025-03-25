using System;
using ReactiveUI;

namespace AvaloniaApplication1.Models;

public class TaskDTO
{
    // private string _taskName = "";
    // private bool _taskStatus;

    // public Guid Id { get; } = Guid.NewGuid();
    public int Id { get; set; }
    public string TaskName { get; set; }
    
    public bool TaskStatus { get; set; }
}