using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArtSiteDashboard.Views;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard;

public class MainWindowViewModel : BaseWindowViewModel {
    public MainWindowViewModel() {
        HomeView = new HomeViewModel(this);
        CharactersView = new CharactersViewModel(this);
        NoCharactersView = new NoCharactersViewModel();
    }
    
    private BaseViewModel _mainView;

    public BaseViewModel MainView {
        get => _mainView;
        set => this.RaiseAndSetIfChanged(ref _mainView, value);
    }

    public HomeViewModel HomeView { get; }
    public CharactersViewModel CharactersView { get; }
    public NoCharactersViewModel NoCharactersView { get; }

    public List<string> MenuItems => new List<string> { "Home", "Characters", "Artworks" };
    
}