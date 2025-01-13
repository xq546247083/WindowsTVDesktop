using System.Windows;

namespace WindowsTVDesktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
            this.DataContext = AppGlobal.ConfigWindowViewModel;

            this.Activated += ConfigWindow_Activated;
            this.KeyDown += ConfigWindow_KeyDown;
        }

        private void ConfigWindow_Activated(object? sender, EventArgs e)
        {
            this.ConfigListBox.Focus();
        }

        private void ConfigWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            AppGlobal.ConfigWindowViewModel.ConfigWindow_KeyDown(e);
        }

        private void ConfigListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AppGlobal.ConfigWindowViewModel.ConfigListBox_MouseLeftButtonUp();
        }
    }
}