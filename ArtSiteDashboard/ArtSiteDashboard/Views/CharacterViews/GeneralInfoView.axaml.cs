using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class GeneralInfoView : ReactiveControl<GeneralInfoView> {
    public GeneralInfoView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    private void Miau(object? sender, RoutedEventArgs e) {
        CharactersViewModel.CharacterChangedEvent();
    }
}