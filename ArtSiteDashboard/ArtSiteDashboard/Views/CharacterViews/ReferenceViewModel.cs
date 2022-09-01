using System.Reactive.Disposables;
using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Views.CharacterViews; 

public class ReferenceViewModel : BaseViewModel{
    public ReferenceViewModel() {
        Activator = new ViewModelActivator();
        this.WhenActivated(Block);
    }
    private async void Block(CompositeDisposable disposables) {
        Disposable.Create(() => { }).DisposeWith(disposables);
    }
    private CharacterModel _currentCharacter;
    public CharacterModel CurrentCharacter {
        get => _currentCharacter;
        set => this.RaiseAndSetIfChanged(ref _currentCharacter, value);
    }
}