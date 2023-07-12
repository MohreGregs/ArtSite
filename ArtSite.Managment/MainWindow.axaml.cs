using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;

namespace ArtSite.Managment {
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {
        
        public MainWindow() {
            InitializeComponent();
        }
        
        public MainWindow(MainWindowViewModel mainWindowViewModel) {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

    }
}