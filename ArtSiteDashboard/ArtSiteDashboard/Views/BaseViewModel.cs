using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public class BaseViewModel : ReactiveObject, IActivatableViewModel
{
    public ViewModelActivator Activator { get; protected init; }
}