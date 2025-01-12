using Hardcodet.Wpf.TaskbarNotification;
using System.Diagnostics;
using System.Windows;
using WindowsTVDesktop.ViewModels;

namespace WindowsTVDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // 如果存在，直接返回
            if (ExistsCurrentProcess())
            {
                System.Environment.Exit(0);
            }

            AppGlobal.Init();

            base.OnStartup(e);
        }

        /// <summary>
        /// 是否存在当前进程
        /// </summary>
        private static bool ExistsCurrentProcess()
        {
            var currentProcess = Process.GetCurrentProcess();

            var processList = Process.GetProcesses();
            foreach (Process item in processList)
            {
                if (item.ProcessName.ToLower() == currentProcess.ProcessName.ToLower() && item.Id != currentProcess.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}