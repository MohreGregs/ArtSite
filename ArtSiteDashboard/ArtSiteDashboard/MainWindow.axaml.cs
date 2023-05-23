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
                    ViewModel.MainView = ViewModel.HomeViewModel;
            });

            AvaloniaXamlLoader.Load(this);
            this.AttachDevTools();
        }

        private void Menu_OnItemChanged(object? sender, SelectionChangedEventArgs e) {
            var listBox = sender as ListBox;
            ViewModel.ChangeView(listBox.SelectedItem.ToString());
        }
    }
}