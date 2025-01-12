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

            Keyboard.AddKeyDownHandler(this, OnKeyDown);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            AppGlobal.MainWindowViewModel.OnKeyDown(e);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = true;
        }
    }
}