using System.Diagnostics;
using System.Windows;
using WindowsTVDesktop.Common;
using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Managers;
using WindowsTVDesktop.Views;

namespace WindowsTVDesktop.ViewModels
{
    public class AppViewModel : ItemViewModel
    {
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

        /// <summary>
        /// 点击
        /// </summary>
        public override void Click()
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
                AppGlobal.ConfigWindow.ShowDialog();
            }
            else if (AppType == AppType.Close)
            {
                Application.Current.MainWindow.Close();
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