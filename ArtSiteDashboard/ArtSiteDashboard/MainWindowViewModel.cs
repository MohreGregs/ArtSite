using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArtSiteDashboard.Views;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard;

public class MainWindowViewModel : BaseWindowViewModel {
    private BaseViewModel _mainView;

    public BaseViewModel MainView {
        get => _mainView;
        set => this.RaiseAndSetIfChanged(ref _mainView, value);
    }
    
    public HomeViewModel HomeViewModel;
    private CharactersViewModel _charactersViewModel;
    public NoCharactersViewModel NoCharactersViewModel;

    public MainWindowViewModel(HomeViewModel homeViewModel, CharactersViewModel charactersViewModel, NoCharactersViewModel noCharactersViewModel) {
        this.HomeViewModel = homeViewModel;
        _charactersViewModel = charactersViewModel;
        NoCharactersViewModel = noCharactersViewModel;
    }

    public List<string> MenuItems => new List<string> { "Home", "Characters", "Artworks" };

    public void ChangeView(string Ja) {
        
        switch (Ja) {
            case "Home": 
                MainView = HomeViewModel;
                break;
            case "Characters":
                MainView = _charactersViewModel;
                break;
            case "Artworks":
                MainView = HomeViewModel;
                break;
        }
    }
}