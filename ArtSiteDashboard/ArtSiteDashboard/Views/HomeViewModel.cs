using System.Reactive.Disposables;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard.Views;

public class HomeViewModel : BaseViewModel{
    private MainWindowViewModel _mainWindowViewModel;
    private Window _mainWindow;

    public HomeViewModel(MainWindowViewModel mainWindowViewModel, Window parent) {
        Activator = new ViewModelActivator();
        this.WhenActivated(disposables => { Disposable.Create(() => { }).DisposeWith(disposables); });

        MainWindow = parent;
        MainWindowViewModel = mainWindowViewModel;
    }
    
    public Window MainWindow {
        get => _mainWindow;
        set => this.RaiseAndSetIfChanged(ref _mainWindow, value);
    }

    public MainWindowViewModel MainWindowViewModel {
        get => _mainWindowViewModel;
        set => this.RaiseAndSetIfChanged(ref _mainWindowViewModel,value);
    }
}