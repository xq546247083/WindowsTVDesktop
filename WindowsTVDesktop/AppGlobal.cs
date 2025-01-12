using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using WindowsTVDesktop.ViewModels;
using WindowsTVDesktop.Views;

namespace WindowsTVDesktop
{
    /// <summary>
    /// 本地信息
    /// </summary>
    public static class AppGlobal
    {
        /// <summary>
        /// 应用名
        /// </summary>
        public static string AppName = "WindowsTVDesktop";

        /// <summary>
        /// 应用名
        /// </summary>
        public static string AppTitle = "Windows电视桌面";

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            Application.Current.MainWindow = MainWindow;
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Activate();

            TaskbarIcon.DataContext = MainTaskbarIconViewModel;
            // todo xiaoqiang
            // 1、在窗体激活时，获取一次显示分辨率，显示在最下面。
            // 2、配置界面 自启动，按钮大小，是否全屏
            // 3、应用的配置界面，ICON，启动参数，名字等
            // 4、优化获取应用的图标，现在的太小了。
        }

        /// <summary>
        /// 主窗口
        /// </summary>
        public static TaskbarIcon TaskbarIcon
        {
            get
            {
                return (TaskbarIcon)Application.Current.FindResource("MainTaskbarIcon");
            }
        }

        /// <summary>
        /// 通知图标ViewModel
        /// </summary>
        private static MainTaskbarIconViewModel mainTaskbarIconViewModel;

        /// <summary>
        /// 通知图标ViewModel
        /// </summary>
        public static MainTaskbarIconViewModel MainTaskbarIconViewModel
        {
            get
            {
                if (mainTaskbarIconViewModel == null)
                {
                    mainTaskbarIconViewModel = new MainTaskbarIconViewModel();
                }

                return mainTaskbarIconViewModel;
            }
        }

        /// <summary>
        /// 主窗口
        /// </summary>
        private static MainWindow mainWindow;

        /// <summary>
        /// 主窗口
        /// </summary>
        public static MainWindow MainWindow
        {
            get
            {
                if (mainWindow == null)
                {
                    mainWindow = new MainWindow();
                }

                return mainWindow;
            }
        }

        /// <summary>
        /// 主窗口ViewModel
        /// </summary>
        private static MainWindowViewModel mainWindowViewModel;

        /// <summary>
        /// 主窗口ViewModel
        /// </summary>
        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                if (mainWindowViewModel == null)
                {
                    mainWindowViewModel = new MainWindowViewModel();
                }

                return mainWindowViewModel;
            }
        }
    }
}