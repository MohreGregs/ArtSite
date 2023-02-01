using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using ArtSite.Data.Enums;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public partial class AddNewCharacterWindow : ReactiveWindow<AddNewCharacterViewModel> {
    public AddNewCharacterWindow() {
        ViewModel = new AddNewCharacterViewModel();
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);

        this.WhenActivated(Block);
    }

    private async void Block(CompositeDisposable obj) {
        ViewModel.Species = (await Api.GetSpecies()) ?? new();
        ViewModel.Artists = (await Api.GetArtists()) ?? new();
        ViewModel.Tags = (await Api.GetTags()) ?? new();
    }

    private async void Button_OnAddSpecies(object? sender, RoutedEventArgs e) {
        var speciesWindow = new AddSpeciesWindow();

        await speciesWindow.ShowDialog(this);
        ViewModel.Species = (await Api.GetSpecies()) ?? new();
    }

    private void AutoCompleteBox_OnSelectionChanged_Species(object? sender, SelectionChangedEventArgs e) {
        var x = sender as AutoCompleteBox;
        ViewModel.CharacterSpecies = (SpeciesModel)x.SelectedItem;
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

    private void SelectingItemsControl_OnSelectionChanged_Gender(object? sender, SelectionChangedEventArgs e) {
        if (ViewModel == null) return;
        var x = sender as ComboBox;

        if (x == null) return;
        
        ViewModel.Character.Gender = (Gender) x.SelectedIndex;
    }

    private void SelectingItemsControl_OnSelectionChanged_Sexuality(object? sender, SelectionChangedEventArgs e) {
        if (ViewModel == null) return;
        var x = sender as ComboBox;

        if (x == null) return;
        
        ViewModel.Character.Sexuality = (Sexuality) x.SelectedIndex;
    }

    private void Button_OnCancel(object? sender, RoutedEventArgs e) {
        Close();
    }

    private void Button_OnAddCharacterPlus(object? sender, RoutedEventArgs e) {
        AddCharacter();
        
        //TODO: Open Edit Character View
    }

    private void Button_OnAddCharacter(object? sender, RoutedEventArgs e) {
        AddCharacter();
        Close();
    }

    private async void AddCharacter() {
        if (string.IsNullOrWhiteSpace(ViewModel.Character.Name) || ViewModel.CharacterDesigner.Id == null) return;

        var tagIds = new List<int>();
        foreach (var tag in ViewModel.CharacterTags) {
            tagIds.Add(tag.Id.Value);
        }

        var characterToAdd = new AddCharacterModel {
            Name = ViewModel.Character.Name,
            Age = ViewModel.Character.Age,
            Gender = ViewModel.Character.Gender,
            Sexuality = ViewModel.Character.Sexuality,
            SpeciesId = ViewModel.CharacterSpecies.Id.Value,
            OriginalDesignerId = ViewModel.CharacterDesigner.Id.Value,
            TagIds = tagIds
        };

        await Api.AddCharacter(characterToAdd);
    }

    private void AutoCompleteBox_OnSelectionChanged_Designer(object? sender, SelectionChangedEventArgs e) {
        var x = sender as AutoCompleteBox;
        ViewModel.CharacterDesigner = (ArtistModel)x.SelectedItem;
    }

    private async void Button_OnAddDesigner(object? sender, RoutedEventArgs e) {
        var artistWindow = new AddArtistWindow();

        await artistWindow.ShowDialog(this);
        ViewModel.Artists = (await Api.GetArtists()) ?? new();
    }
}