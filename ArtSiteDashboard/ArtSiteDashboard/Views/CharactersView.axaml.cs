using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views.CharacterViews;
using Avalonia.Controls;
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
        var character = textblock.DataContext as CharacterModel;
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

        if (ViewModel.CurrentCharacter.Id.Value == null) {
            return;
        }
        
        var mbResult = await Windows.MessageBox.Show(ViewModel.MainWindow, "This will be permanent and cannot be reverted", "Do you really want to delete the character.", Windows.MessageBox.MessageBoxButtons.YesNo);
        if (mbResult != Windows.MessageBox.MessageBoxResult.Yes) { return; }
        
        var result = await Api.DeleteCharacter(ViewModel.CurrentCharacter.Id.Value);

        if (!result.IsSuccessStatusCode) return;

        GetCharacters();
    }

    private async void GetCharacters() {
        var characters = await Api.GetCharacters();
        if (characters.Count == 0) {
            ViewModel.MainWindowViewModel.MainView = ViewModel.MainWindowViewModel.NoCharactersView;
            return;
        }

        ViewModel.Characters = new ObservableCollection<CharacterModel>(characters);
        ViewModel.CurrentCharacter = ViewModel.Characters.FirstOrDefault();
        if (ViewModel.CurrentCharacter == null) return;
        if (ViewModel.CharacterView.GetType() == typeof(GeneralInfoViewModel)) ViewModel.GeneralInfoView.CurrentCharacter = ViewModel.CurrentCharacter;
    }
}