using System.Collections.Generic;
using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class AddTagViewModel: BaseWindowViewModel {
    private TagModel _tag;
    private ColorModel? _color;
    private List<ColorModel> _colors;

    public AddTagViewModel() {
        Tag = new TagModel();
    }

    public TagModel Tag {
        get => _tag;
        set => this.RaiseAndSetIfChanged(ref _tag, value);
    }

    public ColorModel? Color {
        get => _color;
        set => this.RaiseAndSetIfChanged(ref _color, value);
    }

    public List<ColorModel> Colors {
        get => _colors;
        set => this.RaiseAndSetIfChanged(ref _colors, value);
    }
}