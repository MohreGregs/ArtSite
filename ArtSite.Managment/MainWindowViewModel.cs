using Avalonia.Media;
using Nein.Base;
using ReactiveUI;

namespace ArtSite.Managment; 

public class MainWindowViewModel : BaseWindowViewModel {
    private ExperimentalAcrylicMaterial? _panelMaterial;

    public ExperimentalAcrylicMaterial? PanelMaterial {
        get => _panelMaterial;
        set => this.RaiseAndSetIfChanged(ref _panelMaterial, value);
    }

    private BaseViewModel? _mainView;

    public BaseViewModel? MainView {
        get => _mainView;
        set => this.RaiseAndSetIfChanged(ref _mainView, value);
    }

    public MainWindowViewModel() {
        PanelMaterial = new ExperimentalAcrylicMaterial
        {
            BackgroundSource = AcrylicBackgroundSource.Digger,
            TintColor = Colors.Black,
            TintOpacity = 1,
            MaterialOpacity = 0.25
        };
    }
}