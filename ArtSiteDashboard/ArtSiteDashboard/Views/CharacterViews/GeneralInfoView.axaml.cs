using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class GeneralInfoView : UserControl {
    public GeneralInfoView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}