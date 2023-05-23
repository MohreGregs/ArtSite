using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using ArtSite.Data.Enums;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DynamicData;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public partial class AddNewCharacterWindow : ReactiveWindow<AddNewCharacterViewModel> {
   public AddNewCharacterWindow(int? characterId, IMessenger messenger) {
        
        InitializeComponent(characterId);
#if DEBUG
        this.AttachDevTools();
#endif
    }
    
    public AddNewCharacterWindow(){InitializeComponent(null);}

    private void InitializeComponent(int? characterId) {
        AvaloniaXamlLoader.Load(this);

        this.WhenActivated(Block);
    }

    public void SetCharacterId(int id) {
        ViewModel = new AddNewCharacterViewModel(id);
    }

    private async void Block(CompositeDisposable obj) {
        var character = new AddCharacterModel();
        
        if (ViewModel.CharacterId != null) {
            var characterModel = await Api.GetCharacterById(ViewModel.CharacterId.Value);
            
            if (characterModel != null) {
                character.Name = characterModel.Name;
                character.Age = characterModel.Age;
                character.Sexuality = characterModel.Sexuality;
                character.Gender = characterModel.Gender;
                character.WantedArtwork = characterModel.WantedArtwork;
                character.OriginalDesignerId = characterModel.OriginalDesigner.Id.Value;
                character.TagIds = characterModel.Tags.Select(x => x.Id.Value).ToList();
                character.SpeciesId = characterModel.Species.Id.Value;
                
                ViewModel.CharacterTags.Add(characterModel.Tags);
                ViewModel.CharacterDesigner = characterModel.OriginalDesigner;
                ViewModel.CharacterSpecies = characterModel.Species;
            }
        }

        ViewModel.Character = character;
        ViewModel.Species = (await Api.GetSpecies()) ?? new();
        ViewModel.Artists = (await Api.GetArtists()) ?? new();
        ViewModel.Tags = (await Api.GetTags()) ?? new();
    }

    private async void Button_OnAddSpecies(object? sender, RoutedEventArgs e) {
        var speciesWindow = new AddSpeciesWindow();

        await speciesWindow.ShowDialog(this);
        ViewModel.Species = (await Api.GetSpecies()) ?? new();
    }

    private async void Button_OnAddTag(object? sender, RoutedEventArgs e) {
        var tagWindow = new AddTagWindow();

        await tagWindow.ShowDialog(this);
        ViewModel.Tags = (await Api.GetTags()) ?? new();
    }

    private void InputElement_OnKeyUp_Tag(object? sender, KeyEventArgs e) {
        if (e.Key != Key.Enter) return;
    
        var x = sender as AutoCompleteBox;
    
        if (x.SelectedItem == null || ViewModel.CharacterTags.Contains(x.SelectedItem)) return;

        var y = ViewModel.CharacterTags.ToList();
        y.Add((TagModel)x.SelectedItem);
        ViewModel.CharacterTags = new ObservableCollection<TagModel>(y);
        ViewModel.RaisePropertyChanged(nameof(ViewModel.CharacterTags));
        x.Text = "";
    }

    private void Button_OnRemoveTag(object? sender, RoutedEventArgs e) {
        var x = sender as Button;
        var tag = (TagModel) x.DataContext;
        
        if (tag == null) return;

        ViewModel.CharacterTags.Remove(tag);
    }

    private void Button_OnCancel(object? sender, RoutedEventArgs e) {
        Close();
    }

    private void Button_OnAddCharacterPlus(object? sender, RoutedEventArgs e) {
        AddCharacter();
        
        //TODO: Open Character View
    }

    private async void Button_OnAddCharacter(object? sender, RoutedEventArgs e) {
        await AddCharacter();
        Close();
    }

    private async Task AddCharacter() {
        if (string.IsNullOrWhiteSpace(ViewModel.Character.Name) || ViewModel.CharacterDesigner.Id == null) return;

        var tagIds = new List<int>();
        foreach (var tag in ViewModel.CharacterTags) {
            tagIds.Add(tag.Id.Value);
        }

        var characterToAdd = new AddCharacterModel {
            Id = ViewModel.CharacterId ?? -1,
            Name = ViewModel.Character.Name,
            Age = ViewModel.Character.Age,
            Gender = ViewModel.Character.Gender,
            Sexuality = ViewModel.Character.Sexuality,
            SpeciesId = ViewModel.CharacterSpecies.Id.Value,
            OriginalDesignerId = ViewModel.CharacterDesigner.Id.Value,
            TagIds = tagIds
        };

        if (characterToAdd.Id == -1) {
            await Api.AddCharacter(characterToAdd);
        }
        else {
            await Api.EditCharacter(characterToAdd);
        }
    }

    private async void Button_OnAddDesigner(object? sender, RoutedEventArgs e) {
        var artistWindow = new AddArtistWindow();

        await artistWindow.ShowDialog(this);
        ViewModel.Artists = (await Api.GetArtists()) ?? new();
    }
}