using ReactiveUI;

namespace ArtSiteDashboard; 

public class BaseWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();
}