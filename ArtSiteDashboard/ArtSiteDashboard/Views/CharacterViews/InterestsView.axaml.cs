﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class InterestsView : UserControl {
    public InterestsView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}