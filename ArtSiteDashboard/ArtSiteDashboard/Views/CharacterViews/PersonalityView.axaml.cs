using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class PersonalityView : ReactiveControl<PersonalityViewModel> {
    public PersonalityView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    private void PersonalityTrait_OnValueChange(object? sender, RoutedEventArgs e) {
        CharactersViewModel.CharacterChangedEvent();
    }
}