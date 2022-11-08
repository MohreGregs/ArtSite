using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class AddHobbyViewModel : BaseWindowViewModel {
    private string _hobbyName;

    public AddHobbyViewModel() {
        HobbyName = "";
    }

    public string HobbyName {
        get => _hobbyName;
        set => this.RaiseAndSetIfChanged(ref _hobbyName, value);
    }
}