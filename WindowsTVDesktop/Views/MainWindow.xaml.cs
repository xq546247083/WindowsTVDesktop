using System.Windows;
using System.Windows.Input;

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

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            AppGlobal.MainWindowViewModel.OnKeyDown(e);
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            this.AppListBox.Focus();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = true;
        }
    }
}