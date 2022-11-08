using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views.CharacterViews;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard.Views;

public class CharactersViewModel : BaseViewModel {
    public CharactersViewModel(Window mainWindow, MainWindowViewModel mainWindowViewModel) {
        Activator = new ViewModelActivator();
        this.WhenActivated(Block);
        MainWindow = mainWindow;
        MainWindowViewModel = mainWindowViewModel;
        GeneralInfoView = new GeneralInfoViewModel();
        PersonalityView = new PersonalityViewModel();
        InterestsView = new InterestsViewModel();
        AppearanceView = new AppearanceViewModel();
        ReferenceView = new ReferenceViewModel();
    }

    public MainWindowViewModel MainWindowViewModel {
        get => _mainWindowViewModel;
        set => this.RaiseAndSetIfChanged(ref _mainWindowViewModel, value);
    }

    public Window MainWindow {
        get => _mainWindow;
        set => this.RaiseAndSetIfChanged(ref _mainWindow, value);
    }

    private BaseViewModel _characterView;

    public BaseViewModel CharacterView {
        get => _characterView;
        set => this.RaiseAndSetIfChanged(ref _characterView, value);
    }

    public GeneralInfoViewModel GeneralInfoView { get; }
    public PersonalityViewModel PersonalityView { get; }
    public InterestsViewModel InterestsView { get; }
    public AppearanceViewModel AppearanceView { get; }
    public ReferenceViewModel ReferenceView { get; }
    
    private async void Block(CompositeDisposable disposables) {
        Disposable.Create(() => { }).DisposeWith(disposables);
    }

    private ObservableCollection<CharacterModel> _characters;

    private CharacterModel _currentCharacter;
    private ArtworkModel _icon;
    private Window _mainWindow;
    private MainWindowViewModel _mainWindowViewModel;

    public ArtworkModel Icon {
        get => _icon;
        set => this.RaiseAndSetIfChanged(ref _icon, value);
    }

    public ObservableCollection<CharacterModel> Characters {
        get => _characters;
        set {
            this.RaiseAndSetIfChanged(ref _characters, value);
        }
    }

    public CharacterModel CurrentCharacter {
        get => _currentCharacter;
        set {
            this.RaiseAndSetIfChanged(ref _currentCharacter, value);
            GetIcon();
        }
    }

    private async void GetIcon() {
        if (_currentCharacter == null) return;
        var icon = await Api.GetArtworkById(_currentCharacter.IconId);
        if (icon == null) return;
        Icon = icon;
    }
}