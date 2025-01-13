using System.Windows;
using WindowsTVDesktop.ViewModels;

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
        }

        private void ConfigWindow_Activated(object? sender, EventArgs e)
        {
            this.ConfigListBox.Focus();
        }

        private void ConfigListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AppGlobal.ConfigWindowViewModel.ConfigListBox_MouseLeftButtonUp();
        }
    }
}