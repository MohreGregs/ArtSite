﻿using ArtSiteDashboard.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public partial class HomeView : ReactiveControl<HomeViewModel> {
    public HomeView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        this.WhenActivated(_ => {
            if (this.GetVisualRoot() is MainWindow mainWindow) {
                ViewModel.MainWindow = mainWindow;
            }
        });
        
        AvaloniaXamlLoader.Load(this);
    }

    private async void Button_OnAddCharacter(object? sender, RoutedEventArgs e) {
        var newCharacterWindow = new AddNewCharacterWindow();
        await newCharacterWindow.ShowDialog(ViewModel.MainWindow);
    }

    private async void Button_OnAddArtist(object? sender, RoutedEventArgs e) {
        var artistWindow = new AddArtistWindow();
        
        await artistWindow.ShowDialog(ViewModel.MainWindow);
    }

    private async void Button_OnAddColor(object? sender, RoutedEventArgs e) {
        var colorWindow = new AddColorWindow();

        await colorWindow.ShowDialog(ViewModel.MainWindow);
    }

    private async void Button_OnAddArtwork(object? sender, RoutedEventArgs e) {
        var artworkWindow = new AddArtworkWindow();

        await artworkWindow.ShowDialog(ViewModel.MainWindow);
    }

    private async void Button_OnAddTag(object? sender, RoutedEventArgs e) {
        var tagWindow = new AddTagWindow();

        await tagWindow.ShowDialog(ViewModel.MainWindow);
    }

    private async void Button_OnAddSpecies(object? sender, RoutedEventArgs e) {
        var speciesWindow = new AddSpeciesWindow();

        await speciesWindow.ShowDialog(ViewModel.MainWindow);
    }

    private async void Button_OnAddSong(object? sender, RoutedEventArgs e) {
        var hobbyWindow = new AddSongWindow();

        await hobbyWindow.ShowDialog(ViewModel.MainWindow);
    }
}