using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using ArtSite.Data.Models;
using ArtSite.Data.Models.ReactiveModels;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views.CharacterViews;
using ArtSiteDashboard.Windows;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ArtSiteDashboard.Views;

public class CharactersViewModel : BaseViewModel {
    public GeneralInfoViewModel GeneralInfoView { get; }
    public PersonalityViewModel PersonalityView { get; }
    public InterestsViewModel InterestsView { get; }
    public AppearanceViewModel AppearanceView { get; }
    public ReferenceViewModel ReferenceView { get; }
    
    private ObservableCollection<ReactiveCharacterModel> _characters = new();
    private BaseViewModel _characterView;
    
    private ReactiveCharacterModel? _currentCharacter;
    private ArtworkModel _icon;
    private Bitmap _iconImage;
    private MainWindow _mainWindow;

    private bool _characterHasChanged;

    public delegate void CharacterChangedDelegate();
    public static CharacterChangedDelegate CharacterChangedEvent;

    public bool CharacterHasChanged {
        get => _characterHasChanged;
        set => this.RaiseAndSetIfChanged(ref _characterHasChanged, value);
    }   
    
    private readonly AddNewCharacterWindow _addNewCharacterWindow;
    
    public CharactersViewModel(
        AddNewCharacterWindow addNewCharacterWindow,
        GeneralInfoViewModel generalInfoViewModel,
        PersonalityViewModel personalityViewModel,
        InterestsViewModel interestsViewModel,
        AppearanceViewModel appearanceViewModel,
        ReferenceViewModel referenceViewModel
        ) {
        Activator = new ViewModelActivator();
        this.WhenActivated(Block);
        _addNewCharacterWindow = addNewCharacterWindow;
        GeneralInfoView = generalInfoViewModel;
        PersonalityView = personalityViewModel;
        InterestsView = interestsViewModel;
        AppearanceView = appearanceViewModel;
        ReferenceView = referenceViewModel;
        CharacterChangedEvent = delegate { CharacterHasChanged = true;};
    }

    public async Task OpenEditCharacterWindow() {
        _addNewCharacterWindow.SetCharacterId(CurrentCharacter.Id.Value);

        await _addNewCharacterWindow.ShowDialog(MainWindow);
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

    public Bitmap IconImage {
        get => _iconImage;
        set => this.RaiseAndSetIfChanged(ref _iconImage, value);
    }

    public ObservableCollection<ReactiveCharacterModel> Characters {
        get => _characters;
        set {
            this.RaiseAndSetIfChanged(ref _characters, value);
        }
    }

    public ReactiveCharacterModel? CurrentCharacter {
        get => _currentCharacter;
        set {
            this.RaiseAndSetIfChanged(ref _currentCharacter, value);
        }
    }
    
    public void SelectCharacter(ReactiveCharacterModel? character) {
        CurrentCharacter = character;
        GetIcon();
        CharacterView = GeneralInfoView;
        GeneralInfoView.CurrentCharacter = character;
    }

    private async void GetIcon() {
        if (_currentCharacter?.IconId == null) return;
        IconImage = await Api.GetFileById(_currentCharacter.IconId.Value);
    }
}