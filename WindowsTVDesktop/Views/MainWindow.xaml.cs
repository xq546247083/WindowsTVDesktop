using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using WindowsTVDesktop.Managers;

namespace WindowsTVDesktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = AppGlobal.MainWindowViewModel;

            this.Activated += MainWindow_Activated;
            this.KeyDown += MainWindow_KeyDown;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            GlobalHotKeyManager.Init(new WindowInteropHelper(this));
        }

        protected override void OnClosed(EventArgs e)
        {
            GlobalHotKeyManager.UnInit();
            base.OnClosed(e);
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            this.AppListBox.Focus();
            AppGlobal.MainWindowViewModel.MainWindow_Activated();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = true;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Apps)
            {
                this.AppListBox.ContextMenu.IsOpen = true;
            }
        }

        private void AppListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AppGlobal.MainWindowViewModel.AppListBox_MouseLeftButtonUp();
        }
    }
}