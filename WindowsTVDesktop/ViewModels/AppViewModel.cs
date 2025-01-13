using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.IO;
using System.Windows;
using WindowsTVDesktop.Common;
using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Managers;

namespace WindowsTVDesktop.ViewModels
{
    public class AppViewModel : ObservableObject
    {
        public string Name
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public string IconPath
        {
            get;
            set;
        }

        public string StartPath
        {
            get;
            set;
        }

        public string StartArgs
        {
            get;
            set;
        }

        public AppType AppType
        {
            get;
            set;
        }

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(IconPath))
                {
                    return Name;
                }

                return string.Empty;
            }
        }

        public string IconPathExt
        {
            get
            {
                if (string.IsNullOrEmpty(IconPath))
                {
                    return IconPath;
                }

                return Path.GetFullPath(IconPath);
            }
        }

        /// <summary>
        /// 点击
        /// </summary>
        public void Click()
        {
            if (AppType == AppType.Add)
            {
                var openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Filter = "程序文件|*.exe";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Title = "选择程序";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var config = ConfigManager.GetConfig();
                    if (config.AppInfoList.All(r => r.StartPath != openFileDialog.FileName))
                    {
                        config.AppInfoList.Add(AppHelper.ReadApp(openFileDialog.FileName));
                        ConfigManager.Save(config);

                        AppGlobal.MainWindowViewModel.ReLoad();
                    }
                    else
                    {
                        UIHelper.ShowToolTip("已经添加过该应用！");
                    }
                }
            }
            else if (AppType == AppType.Config)
            {

            }
            else if (AppType == AppType.Exit)
            {
                Application.Current.Shutdown();
            }
            else if (AppType == AppType.Desktop)
            {
                var process = new Process();
                process.StartInfo.FileName = StartPath;
                process.StartInfo.Arguments = StartArgs;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

                process.Start();
            }
        }
    }
}