using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using AvaloniaApplication1.Mediators;
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

    private ObservableCollection<TaskDTO> _tasksList = new()
    {

    };

    private readonly Mediator _mediator;

    public ObservableCollection<TaskDTO> TasksList
    {
        get => _tasksList;
        set => this.RaiseAndSetIfChanged(ref _tasksList, value);
    }


    public ReactiveCommand<Unit, Unit> LoadStorageCommand { get; set; }
    public ReactiveCommand<Unit, Unit> SaveStorageCommand { get; set; }
    public ReactiveCommand<Unit, Unit> AddTaskCommand { get; set; }
    public ReactiveCommand<Unit, Unit> ClearTableCommand { get; set; }
    
    
    public MainWindowViewModel(ITaskService taskService, Mediator mediator)
    {
        _taskService = taskService;
        _mediator = mediator;
        
        _mediator.Subscribe<NewClass>(GetNewClass);
        
        LoadStorageCommand = ReactiveCommand.Create(() =>
        {
            TasksList.Clear();
            TasksList.AddRange(_taskService.GetAllTasks());
        });

        SaveStorageCommand = ReactiveCommand.Create(() =>
        {
            _taskService.AddRangeTasks(TasksList);
        });

        AddTaskCommand = ReactiveCommand.Create(() =>
        {
            TasksList.Add(_taskService.AddTask(new TaskDTO()
            {
                TaskName = "New Task",
                TaskStatus = false
            }));
            // _taskService.AddTask(new TaskDTO()
            // {
            //     TaskName = "New Task",
            //     TaskStatus = false
            // });
        });
    }

    private void GetNewClass(NewClass newClass)
    {
        Debug.WriteLine(newClass.txt1);
    }
}