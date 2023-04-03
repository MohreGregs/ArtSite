using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSite.Dashboard.CustomControls; 

public partial class PersonalityTrait : UserControl {
    public static readonly StyledProperty<string> TextLeftProperty =
        AvaloniaProperty.Register<InputRow, string>(nameof(TextLeft));
    
    public string TextLeft {
        get => GetValue(TextLeftProperty);
        set => SetValue(TextLeftProperty, value);
    }
    
    public static readonly StyledProperty<string> TextRightProperty =
        AvaloniaProperty.Register<InputRow, string>(nameof(TextRight));
    
    public string TextRight {
        get => GetValue(TextRightProperty);
        set => SetValue(TextRightProperty, value);
    }
    
    public static readonly StyledProperty<double> SliderValueProperty =
        AvaloniaProperty.Register<InputRow, double>(nameof(SliderValue));
    
    public double SliderValue {
        get => GetValue(SliderValueProperty);
        set {
            SetValue(SliderValueProperty, value); 
            var eventargs = new RoutedEventArgs { RoutedEvent = ValueChangeEvent };
            RaiseEvent(eventargs);
        }
    }

    public static readonly RoutedEvent<RoutedEventArgs> ValueChangeEvent =
        RoutedEvent.Register<MarkUpViewer, RoutedEventArgs>(nameof(ValueChange), RoutingStrategies.Bubble);
    
    public event EventHandler<RoutedEventArgs> ValueChange {
        add => AddHandler(ValueChangeEvent, value);
        remove => RemoveHandler(ValueChangeEvent, value);
    } 
    
    public PersonalityTrait() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}