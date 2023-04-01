using System.Reactive.Disposables;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public class NoCharactersViewModel : BaseViewModel{
    private MainWindow _mainWindow;

    public NoCharactersViewModel() {
        Activator = new ViewModelActivator();
        this.WhenActivated(disposables => { Disposable.Create(() => { }).DisposeWith(disposables); });
    }

    public MainWindow MainWindow {
        get => _mainWindow;
        set => this.RaiseAndSetIfChanged(ref _mainWindow, value);
    }
}