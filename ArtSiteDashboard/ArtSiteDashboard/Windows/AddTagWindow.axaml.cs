using System.Reactive.Disposables;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public partial class AddTagWindow : ReactiveWindow<AddTagViewModel> {
    public AddTagWindow() {
        InitializeComponent();

        ViewModel = new AddTagViewModel();
            
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);

        this.WhenActivated(Block);
    }
    
    private async void Block(CompositeDisposable obj) {
        ViewModel.Colors = (await Api.GetColors()) ?? new();
    }

    private void Button_OnCancel(object? sender, RoutedEventArgs e) {
        Close();
    }

    private async void Button_OnAdd(object? sender, RoutedEventArgs e) {
        if (string.IsNullOrWhiteSpace(ViewModel.Tag.Name) || ViewModel.Color == null) {
            return;
        }
        
        var tagToAdd = new {
            Name = ViewModel.Tag.Name,
            ColorId = ViewModel.Color.Id,
        };
        
        var x = await Api.AddTag(tagToAdd);
        
        Close();
    }

    private async void Button_OnAddColor(object? sender, RoutedEventArgs e) {
        var colorWindow = new AddColorWindow();

        await colorWindow.ShowDialog(this);
        ViewModel.Colors = (await Api.GetColors()) ?? new();
    }

    private void AutoCompleteBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        var x = sender as AutoCompleteBox;
        ViewModel.Color = (ColorModel)x.SelectedItem;
    }
}