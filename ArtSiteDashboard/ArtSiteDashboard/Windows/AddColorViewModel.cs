using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class AddColorViewModel : BaseWindowViewModel {
    private ColorModel _color;

    public ColorModel Color {
        get => _color;
        set => this.RaiseAndSetIfChanged(ref _color, value);
    }

    public AddColorViewModel() {
        Color = new ColorModel();
    }

}