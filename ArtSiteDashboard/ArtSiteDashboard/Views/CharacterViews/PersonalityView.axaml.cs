using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class PersonalityView : UserControl {
    public PersonalityView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}