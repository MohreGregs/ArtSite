using System.Reactive.Disposables;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard.Views;

public class HomeViewModel : BaseViewModel{
    private Window _mainWindow;

    public HomeViewModel() {
        Activator = new ViewModelActivator();
        this.WhenActivated(disposables => { Disposable.Create(() => { }).DisposeWith(disposables); });
    }
    
    public Window MainWindow {
        get => _mainWindow;
        set => this.RaiseAndSetIfChanged(ref _mainWindow, value);
    }

}