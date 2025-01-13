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

        /// <summary>
        /// 配置
        /// </summary>
        private static ConfigWindow configWindow;

        /// <summary>
        /// 配置
        /// </summary>
        public static ConfigWindow ConfigWindow
        {
            get
            {
                if (configWindow == null)
                {
                    configWindow = new ConfigWindow();
                }

                return configWindow;
            }
        }

        /// <summary>
        /// 配置ViewModel
        /// </summary>
        private static ConfigWindowViewModel configWindowViewModel;

        /// <summary>
        /// 配置ViewModel
        /// </summary>
        public static ConfigWindowViewModel ConfigWindowViewModel
        {
            get
            {
                if (configWindowViewModel == null)
                {
                    configWindowViewModel = new ConfigWindowViewModel();
                }

                return configWindowViewModel;
            }
        }

        public static void CloseConfigWindow()
        {
            configWindow?.Close();
            configWindow = null;
            configWindowViewModel = null;
        }
    }
}