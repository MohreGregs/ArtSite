using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class AppearanceView : UserControl {
    public AppearanceView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}