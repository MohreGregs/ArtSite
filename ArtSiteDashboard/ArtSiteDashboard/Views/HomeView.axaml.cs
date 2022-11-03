﻿using ArtSiteDashboard.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views; 

public partial class HomeView : ReactiveControl<HomeViewModel> {
    public HomeView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
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
}