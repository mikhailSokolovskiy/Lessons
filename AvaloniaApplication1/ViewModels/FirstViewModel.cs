using System.Reactive;
using AvaloniaApplication1.Mediators;
using AvaloniaApplication1.Service.Realizations;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

public class FirstViewModel : ViewModelBase
{
    private readonly Mediator _mediator;
    public ReactiveCommand<Unit, Unit> SendMessageCommand { get; }

    public FirstViewModel(Mediator mediator)
    {
        _mediator = mediator;

        SendMessageCommand = ReactiveCommand.Create(() =>
        {
            SendMessage();
            SendMessage2();
        });
    }

    private void SendMessage()
    {
        _mediator.Send(new NewClass());
    }

    private void SendMessage2()
    {
        _mediator.Send(Text);
    }

    private string _text;

    public string Text
    {
        get => _text;
        set => this.RaiseAndSetIfChanged(ref _text, value);
    }

}