using ArtSiteDashboard.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public partial class NoCharactersView : ReactiveControl<NoCharactersViewModel> {
    public NoCharactersView() {
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

    private async void Button_OnClick(object? sender, RoutedEventArgs e) {
        var newCharacterWindow = new AddNewCharacterWindow();
        await newCharacterWindow.ShowDialog(ViewModel.MainWindow);
    }
}