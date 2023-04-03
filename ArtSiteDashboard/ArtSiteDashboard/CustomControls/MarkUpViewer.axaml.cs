using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSite.Dashboard.CustomControls; 

public partial class MarkUpViewer : UserControl {
    public static readonly StyledProperty<string> RawMarkUpProperty =
        AvaloniaProperty.Register<TextBox, string>(nameof(RawMarkUp), defaultBindingMode: BindingMode.TwoWay);
    
    public string RawMarkUp {
        get => GetValue(RawMarkUpProperty);
        set {
            SetValue(RawMarkUpProperty, value);
            var eventargs = new RoutedEventArgs { RoutedEvent = TextEvent };
            RaiseEvent(eventargs);
        }
    }

    public static readonly RoutedEvent<RoutedEventArgs> TextEvent =
        RoutedEvent.Register<MarkUpViewer, RoutedEventArgs>(nameof(Text), RoutingStrategies.Bubble);
    
    public event EventHandler<RoutedEventArgs> Text {
        add => AddHandler(TextEvent, value);
        remove => RemoveHandler(TextEvent, value);
    } 

    public MarkUpViewer() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}