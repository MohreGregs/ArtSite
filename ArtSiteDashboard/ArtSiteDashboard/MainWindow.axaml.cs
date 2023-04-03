using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace ArtSiteDashboard {
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {
        public MainWindow() {
            InitializeComponent();
        }

        public MainWindow(MainWindowViewModel viewModel) {
            ViewModel = viewModel;
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                if (ViewModel != null)
                    ViewModel.MainView = ViewModel.HomeView;
            });

            AvaloniaXamlLoader.Load(this);
            this.AttachDevTools();
        }

        private void Menu_OnItemChanged(object? sender, SelectionChangedEventArgs e) {
            var listBox = sender as ListBox;
            switch (listBox.SelectedItem.ToString()) {
                case "Home":
                    ViewModel.MainView = ViewModel.HomeView;
                    break;
                case "Characters":
                    ViewModel.MainView = ViewModel.CharactersView;
                    break;
                case "Artworks":
                    ViewModel.MainView = ViewModel.HomeView;
                    break;
            }
        }
    }
}