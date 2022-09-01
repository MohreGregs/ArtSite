using System.Collections.ObjectModel;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using ArtSiteDashboard.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Windows; 

public partial class AddNewCharacterWindow : ReactiveWindow<AddNewCharacterViewModel> {
    public AddNewCharacterWindow() {
        ViewModel = new AddNewCharacterViewModel();
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    private async void GetSpecies() {
        var species = await Api.GetSpecies();
        if (species.Count == 0) {
            
        }
        ViewModel.Species = new Collection<SpeciesModel>(species);
    }
}