using System;

namespace AvaloniaApplication1.Models;

public class TaskDTO
{
    public Guid Id { get; } = Guid.NewGuid();
    public string TaskName { get; set; } = "";
    public bool TaskStatus { get; set; }
}