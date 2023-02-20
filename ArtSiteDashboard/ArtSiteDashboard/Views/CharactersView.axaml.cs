using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using ArtSite.Data.Enums;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views.CharacterViews;
using ArtSiteDashboard.Windows;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public partial class CharactersView : ReactiveControl<CharactersViewModel> {
    public CharactersView() {
        InitializeComponent();
        
    }

    private void InitializeComponent() {
        this.WhenActivated(Block);
        
        AvaloniaXamlLoader.Load(this);
    }

    private async void Block(Action<IDisposable> disposables) {
        if (ViewModel != null) {
            ViewModel.CharacterView = ViewModel.GeneralInfoView;
        }

        GetCharacters();
    }

    private async void View_OnInitialize(object? sender, EventArgs e) {
        
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e) {
        var button = sender as Button;
        switch (button.Name) {
            case "GeneralInfoButton":
                ViewModel.CharacterView = ViewModel.GeneralInfoView;
                ViewModel.GeneralInfoView.CurrentCharacter = ViewModel.CurrentCharacter;
                break;
            case "PersonalityButton":
                ViewModel.CharacterView = ViewModel.PersonalityView;
                ViewModel.PersonalityView.CurrentCharacter = ViewModel.CurrentCharacter;
                break;
            case "InterestsButton":
                ViewModel.CharacterView = ViewModel.InterestsView;
                ViewModel.InterestsView.CurrentCharacter = ViewModel.CurrentCharacter;
                break;
            case "AppearanceButton":
                ViewModel.AppearanceView.CurrentCharacter = ViewModel.CurrentCharacter;
                ViewModel.CharacterView = ViewModel.AppearanceView;
                break;
            case "ReferenceButton":
                ViewModel.ReferenceView.CurrentCharacter = ViewModel.CurrentCharacter;
                ViewModel.CharacterView = ViewModel.ReferenceView;
                break;
        }
    }

    private void Designer_OnTapped(object? sender, RoutedEventArgs e) {
        var textblock = sender as TextBlock;
        if (textblock == null) return;
        var character = textblock.DataContext as CharacterModel;
        if (character == null || character.OriginalDesigner.Name == "Unknown") return;
        
        var url = character.OriginalDesigner.Furaffinity;
        try
        {
            //try to open the url in the default browser
            Process.Start(url);
        }
        catch //If we fail we converter use the native platforms commands
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true
                });

                return;
            }
        }
    }

    private async void Delete_OnClick(object? sender, RoutedEventArgs e) {

        if (ViewModel.CurrentCharacter?.Id == null) {
            return;
        }
        
        var mbResult = await Windows.MessageBox.Show(ViewModel.MainWindow, "This will be permanent and cannot be reverted", "Do you really want to delete the character.", Windows.MessageBox.MessageBoxButtons.YesNo);
        if (mbResult != Windows.MessageBox.MessageBoxResult.Yes) { return; }
        
        var result = await Api.DeleteCharacter(ViewModel.CurrentCharacter.Id.Value);

        if (!result.IsSuccessStatusCode) return;

        GetCharacters();
    }

    private async void GetCharacters() {
        var characters = await Api.GetCharacters() ?? new();
        if (characters.Count == 0) {
            ViewModel.MainWindowViewModel.MainView = ViewModel.MainWindowViewModel.NoCharactersView;
            return;
        }

        ViewModel.Characters = new ObservableCollection<CharacterModel>(characters);
        ViewModel.CurrentCharacter = ViewModel.Characters.FirstOrDefault();
        if (ViewModel.CurrentCharacter == null) return;
        if (ViewModel.CharacterView.GetType() == typeof(GeneralInfoViewModel)) ViewModel.GeneralInfoView.CurrentCharacter = ViewModel.CurrentCharacter;
    }

    private async void Icon_OnDoubleTap(object? sender, RoutedEventArgs e) {
        var hobbyWindow = new ChooseImageWindow(ViewModel.CurrentCharacter.Id.Value);

        await hobbyWindow.ShowDialog(ViewModel.MainWindow);
        GetCharacters();
    }

    private void Button_OnRevertChanges(object? sender, RoutedEventArgs e) {
        throw new NotImplementedException();
    }

    private void Button_OnSaveChanges(object? sender, RoutedEventArgs e) {
        throw new NotImplementedException();
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        if (ViewModel.HasChanged) {
            return;
        }
        CharacterChanged();
    }

    private void CharacterChanged() {
        ViewModel.CurrentCharacterTags = new ObservableCollection<TagModel>(ViewModel.CurrentCharacter.Tags);
    }

    private void InputElement_OnKeyDown(object? sender, KeyEventArgs e) {
        ViewModel.HasChanged = true;
    }

    private void InputElement_OnKeyUp_Tag(object? sender, KeyEventArgs e) {
        if (e.Key != Key.Enter) return;

        var x = sender as AutoCompleteBox;

        if (x.SelectedItem == null || ViewModel.CurrentCharacterTags.Contains(x.SelectedItem)) return;

        var y = ViewModel.CurrentCharacterTags.ToList();
        y.Add((TagModel)x.SelectedItem);
        ViewModel.CurrentCharacterTags = new ObservableCollection<TagModel>(y);
        ViewModel.RaisePropertyChanged(nameof(ViewModel.CurrentCharacter.Tags));
        x.Text = "";
    }

    private async void Button_OnAddTag(object? sender, RoutedEventArgs e) {
        var tagWindow = new AddTagWindow();

        await tagWindow.ShowDialog(ViewModel.MainWindow);
        ViewModel.Tags = (await Api.GetTags()) ?? new();
    }

    private void Button_OnRemoveTag(object? sender, RoutedEventArgs e) {
        var x = sender as Button;
        var tag = (TagModel) x.DataContext;
        
        if (tag == null) return;

        ViewModel.CurrentCharacterTags.Remove(tag);
    }

    private async void Button_OnAddSpecies(object? sender, RoutedEventArgs e) {
        var speciesWindow = new AddSpeciesWindow();

        await speciesWindow.ShowDialog(ViewModel.MainWindow);
        ViewModel.Species = (await Api.GetSpecies()) ?? new();
    }

    private void AutoCompleteBox_OnSelectionChanged_Species(object? sender, SelectionChangedEventArgs e) {
        var x = sender as AutoCompleteBox;
        ViewModel.CurrentCharacter.Species = (SpeciesModel)x.SelectedItem;
    }

    private async void Button_OnAddDesigner(object? sender, RoutedEventArgs e) {
        var artistWindow = new AddArtistWindow();

        await artistWindow.ShowDialog(ViewModel.MainWindow);
        ViewModel.Artists = (await Api.GetArtists()) ?? new();
    }

    private void AutoCompleteBox_OnSelectionChanged_Designer(object? sender, SelectionChangedEventArgs e) {
        var x = sender as AutoCompleteBox;
        ViewModel.CurrentCharacter.OriginalDesigner = (ArtistModel)x.SelectedItem;
    }

    private void SelectingItemsControl_OnSelectionChanged_Gender(object? sender, SelectionChangedEventArgs e) {
        if (ViewModel == null) return;
        var x = sender as ComboBox;

        if (x == null) return;
        
        ViewModel.CurrentCharacter.Gender = (Gender) x.SelectedIndex;
    }

    private void SelectingItemsControl_OnSelectionChanged_Sexuality(object? sender, SelectionChangedEventArgs e) {
        if (ViewModel == null) return;
        var x = sender as ComboBox;

        if (x == null) return;
        
        ViewModel.CurrentCharacter.Sexuality = (Sexuality) x.SelectedIndex;
    }
}