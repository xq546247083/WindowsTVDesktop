using System.Windows;

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
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = true;
        }
    }
}