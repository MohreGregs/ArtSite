using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class InterestsView : UserControl {
    public InterestsView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    private void MarkUpViewer_OnText(object? sender, RoutedEventArgs e) {
        CharactersViewModel.CharacterChangedEvent();
    }
}