using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using ArtSite.Data.Models;
using ArtSite.Data.Models.ReactiveModels;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views.CharacterViews;
using Avalonia.Controls;
using ReactiveUI;

namespace ArtSiteDashboard.Views;

public class CharactersViewModel : BaseViewModel {
    public GeneralInfoViewModel GeneralInfoView { get; }
    public PersonalityViewModel PersonalityView { get; }
    public InterestsViewModel InterestsView { get; }
    public AppearanceViewModel AppearanceView { get; }
    public ReferenceViewModel ReferenceView { get; }
    
    private ObservableCollection<CharacterModel> _characters = new();
    private BaseViewModel _characterView;

    private ReactiveCharacterModel? _currentCharacter;
    private ArtworkModel _icon;
    private MainWindow _mainWindow;
    private MainWindowViewModel _mainWindowViewModel;
    
    public CharactersViewModel(MainWindowViewModel mainWindowViewModel) {
        Activator = new ViewModelActivator();
        this.WhenActivated(Block);
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

    public MainWindow MainWindow {
        get => _mainWindow;
        set => this.RaiseAndSetIfChanged(ref _mainWindow, value);
    }

    public BaseViewModel CharacterView {
        get => _characterView;
        set => this.RaiseAndSetIfChanged(ref _characterView, value);
    }

    private async void Block(CompositeDisposable disposables) {
        Disposable.Create(() => { }).DisposeWith(disposables);
    }
    
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

    public ReactiveCharacterModel? CurrentCharacter {
        get => _currentCharacter;
        set {
            this.RaiseAndSetIfChanged(ref _currentCharacter, value);
            GetIcon();
        }
    }

    private async void GetIcon() {
        if (_currentCharacter == null) return;
        var icon = await Api.GetArtworkById(_currentCharacter.IconId.Value);
        if (icon == null) return;
        Icon = icon;
    }
}