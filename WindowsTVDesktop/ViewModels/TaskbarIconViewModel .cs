using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace WindowsTVDesktop.ViewModels
{
    public class MainTaskbarIconViewModel : ObservableObject
    {
        /// <summary>
        /// 点击通知按钮
        /// </summary>
        public RelayCommand<object> ClickCommand => new RelayCommand<object>(Click);

        /// <summary>
        /// 点击通知按钮
        /// </summary>
        /// <param name="commandParameterEx">参数</param>
        private void Click(object? type)
        {
            if (type == null) 
            {
                return;
            }
            else if (type.ToString() == "Show")
            {
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.Activate();
            }
            else if (type.ToString() == "Hide")
            {
                Application.Current.MainWindow.Hide();
            }
            else if (type.ToString() == "Shutdown")
            {
                Application.Current.Shutdown();
            }
            else if (type.ToString() == "AutoStart")
            {
            }
        }
    }
}