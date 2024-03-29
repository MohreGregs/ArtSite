﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ArtSite.Data.Models;
using ArtSite.Data.Models.ReactiveModels;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views.CharacterViews;
using ArtSiteDashboard.Windows;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Avalonia.VisualTree;
using DynamicData;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public partial class CharactersView : ReactiveControl<CharactersViewModel> {
    private MainWindowViewModel _mainWindowViewModel;

    public CharactersView() {
        InitializeComponent();

    }
    
    public CharactersView(MainWindowViewModel mainWindowViewModel) {
        InitializeComponent();
        _mainWindowViewModel = mainWindowViewModel;
    }

    private void InitializeComponent() {
        this.WhenActivated(Block);
        
        AvaloniaXamlLoader.Load(this);
    }

    private async void Block(Action<IDisposable> disposables) {
        if (this.GetVisualRoot() is MainWindow mainWindow) {
            ViewModel.MainWindow = mainWindow;
        }
        
        if (ViewModel != null) {
            ViewModel.CharacterView = ViewModel.GeneralInfoView;
        }

        await GetCharacters();
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

        await GetCharacters();
    }

    private List<CharacterModel>? characters;
    
    private async Task GetCharacters() {
        if (characters == null) {
            characters = await Api.GetCharacters() ?? new();
        }
        
        if (characters.Count == 0) {
            _mainWindowViewModel.MainView = _mainWindowViewModel.NoCharactersViewModel;
            return;
        }

        CreateReactiveChars();
        
        ViewModel.SelectCharacter(ViewModel.Characters.FirstOrDefault());
        
        if (ViewModel.CurrentCharacter == null) return;
        if (ViewModel.CharacterView.GetType() == typeof(GeneralInfoViewModel)) ViewModel.GeneralInfoView.CurrentCharacter = ViewModel.CurrentCharacter;
    }

    private void CreateReactiveChars() {
        ViewModel.Characters.Clear();
        ViewModel.Characters.AddRange(characters.Select(x => ReactiveCharacterModel.FromCharacterModel(x)));
    }

    private async void Icon_OnDoubleTap(object? sender, RoutedEventArgs e) {
        var iconWindow = new ChooseImageWindow(ViewModel.CurrentCharacter.Id.Value);
        
        await iconWindow.ShowDialog(ViewModel.MainWindow);
        await GetCharacters();
    }

    private async void Edit_OnClick(object? sender, RoutedEventArgs e) {
        await ViewModel.OpenEditCharacterWindow();
    }

    private void HasChanged() {
        ViewModel.CharacterHasChanged = true;
    }

    private async void Button_OnSave(object? sender, RoutedEventArgs e) {
        var characterToEdit = new EditCharacterModel();
        characterToEdit.Id = ViewModel.CurrentCharacter.Id;
        characterToEdit.GeneralInfo = ReactiveGeneralInfoModel.ToGeneralInfoModel(ViewModel.CurrentCharacter.GeneralInfo);
        characterToEdit.Personality = ReactivePersonalityModel.ToPersonalityModel(ViewModel.CurrentCharacter.Personality);
        characterToEdit.Appearance = ReactiveAppearanceModel.ToAppearanceModel(ViewModel.CurrentCharacter.Appearance);
        characterToEdit.Interests = ReactiveInterestsModel.ToInterestModel(ViewModel.CurrentCharacter.Interests);

        await Api.EditExtraCharacterInfo(characterToEdit);

        ViewModel.CharacterHasChanged = false;
    }

    private void Button_OnRevert(object? sender, RoutedEventArgs e) {
        var id = ViewModel.CurrentCharacter.Id;
        CreateReactiveChars();

        var character = ViewModel.Characters.FirstOrDefault(x => x.Id == id);
        
        ViewModel.SelectCharacter(character);
        ViewModel.CharacterHasChanged = false;
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        if (e.AddedItems.Count > 0) {
            var x = e.AddedItems[0] as ReactiveCharacterModel;
            ViewModel.SelectCharacter(x);
        }
    }
}