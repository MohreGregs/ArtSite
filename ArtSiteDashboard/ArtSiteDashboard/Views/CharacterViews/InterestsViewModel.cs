﻿using System.Reactive.Disposables;
using ArtSite.Data.Models;
using ArtSite.Data.Models.ReactiveModels;
using ReactiveUI;

namespace ArtSiteDashboard.Views.CharacterViews; 

public class InterestsViewModel : BaseViewModel {
    public InterestsViewModel() {
        Activator = new ViewModelActivator();
        this.WhenActivated(Block);
    }
    private async void Block(CompositeDisposable disposables) {
        Disposable.Create(() => { }).DisposeWith(disposables);
    }
    private ReactiveCharacterModel _currentCharacter;
    public ReactiveCharacterModel CurrentCharacter {
        get => _currentCharacter;
        set => this.RaiseAndSetIfChanged(ref _currentCharacter, value);
    }
}