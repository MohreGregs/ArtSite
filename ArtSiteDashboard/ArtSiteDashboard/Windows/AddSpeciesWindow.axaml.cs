using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Windows; 

public partial class AddSpeciesWindow : ReactiveWindow<AddSpeciesViewModel> {
    public AddSpeciesWindow() {
        InitializeComponent();

        ViewModel = new AddSpeciesViewModel();
        
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    private void Button_OnCancel(object? sender, RoutedEventArgs e) {
        Close();
    }

    private async void Button_OnAdd(object? sender, RoutedEventArgs e) {
        if (string.IsNullOrWhiteSpace(ViewModel.Species.Name)) {
            return;
        }
        
        var speciesToAdd = new {
            Name = ViewModel.Species.Name,
        };
        
        var x = await Api.AddSpecies(speciesToAdd);
        
        Close();
    }
}