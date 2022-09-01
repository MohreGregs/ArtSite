using System.Reactive.Disposables;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public class NoCharactersViewModel : BaseViewModel{
    private Window _mainWindow;

    public NoCharactersViewModel(Window parent) {
        MainWindow = parent;
        Activator = new ViewModelActivator();
        this.WhenActivated(disposables => { Disposable.Create(() => { }).DisposeWith(disposables); });
    }

    public Window MainWindow {
        get => _mainWindow;
        set => this.RaiseAndSetIfChanged(ref _mainWindow, value);
    }
}