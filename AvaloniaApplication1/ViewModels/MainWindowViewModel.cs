using System;
using System.Collections.ObjectModel;
using System.Reactive;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Service;
using DynamicData;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

/*
 * Создать приложение для добавления/редактирования/удаления задач, которое так же будет позволять отмечать их как завершённые
 */
public class MainWindowViewModel : ViewModelBase
{
    private ITaskService _taskService;
    private IStorageService<TaskDTO> _taskStorageService;
    private ObservableCollection<TaskDTO> _tasksList = new()
    {
        new TaskDTO
        {
            TaskName = "Task1",
            TaskStatus = false
        }
    };
    public ObservableCollection<TaskDTO> TasksList
    {
        get => _tasksList;
        set => this.RaiseAndSetIfChanged(ref _tasksList, value);
    }
    
    
    public ReactiveCommand<Unit, Unit> LoadStorageCommand { get; set; }
    public ReactiveCommand<Unit, Unit> SaveStorageCommand {get;set;}
    public ReactiveCommand<Unit, Unit> AddTaskCommand { get; set; }
    public ReactiveCommand<Unit, Unit> ClearTableCommand { get; set; }
    
    public MainWindowViewModel(ITaskService taskService, IStorageService<TaskDTO> taskStorageService)
    {
        _taskService = taskService;
        _taskStorageService = taskStorageService;
        TasksList.Add(new ()
        {
            TaskName = "New Task",
            TaskStatus = false
        });
        
        LoadStorageCommand = ReactiveCommand.Create(() =>
        {
            TasksList.Clear();
            TasksList.AddRange(_taskStorageService.Load());
            _taskService.AddRangeTasks(TasksList);
        });

        SaveStorageCommand = ReactiveCommand.Create(() => { _taskStorageService.Save(TasksList); });

        AddTaskCommand = ReactiveCommand.Create(() =>
        {
            TasksList.Add(new TaskDTO()
            {
                TaskName = "New Task",
                TaskStatus = false
            });
            _taskService.AddTask(new TaskDTO()
            {
                TaskName = "New Task",
                TaskStatus = false
            });
        });
    }
}