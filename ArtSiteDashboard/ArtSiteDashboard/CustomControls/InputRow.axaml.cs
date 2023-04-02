using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtSite.Dashboard.CustomControls; 

public partial class InputRow : UserControl {
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<InputRow, string>(nameof(Title));
    
    public string Title {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public static readonly StyledProperty<Control> InputControlProperty =
        AvaloniaProperty.Register<InputRow, Control>(nameof(InputControl));
    
    public Control InputControl {
        get => GetValue(InputControlProperty);
        set => SetValue(InputControlProperty, value);
    }
    
    public static readonly StyledProperty<Control> ExtraControlProperty =
        AvaloniaProperty.Register<InputRow, Control>(nameof(ExtraControl));
    
    public Control ExtraControl {
        get => GetValue(ExtraControlProperty);
        set => SetValue(ExtraControlProperty, value);
    }
    
    public InputRow() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}