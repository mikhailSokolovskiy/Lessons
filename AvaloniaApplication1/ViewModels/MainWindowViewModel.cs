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
    private IStorageService _storageService;

    public ObservableCollection<TaskDTO> TasksList;
    public ReactiveCommand<Unit, Unit> LoadStorage;
    public ReactiveCommand<Unit, Unit> SaveStorage;
    public ReactiveCommand<Unit, Unit> AddTask;

    public MainWindowViewModel(ITaskService taskService, IStorageService storageService)
    {
        _taskService = taskService;
        _storageService = storageService;
        TasksList = new ObservableCollection<TaskDTO>();

        LoadStorage = ReactiveCommand.Create(() =>
        {
            TasksList.Clear();
            TasksList.AddRange(_storageService.LoadTasks());
            _taskService.AddRangeTasks(TasksList);
        });

        SaveStorage = ReactiveCommand.Create(() => { _storageService.SaveTasks(TasksList); });

        AddTask = ReactiveCommand.Create(() =>
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