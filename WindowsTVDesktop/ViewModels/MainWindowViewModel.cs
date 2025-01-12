using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Controls;
using WindowsTVDesktop.Common;
using WindowsTVDesktop.Models;

namespace WindowsTVDesktop.ViewModels
{
    /// <summary>
    /// 主界面的ViewModel
    /// </summary>
    public class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public MainWindowViewModel()
        {
            ReLoad();
        }

        #region 绑定属性

        /// <summary>
        /// 应用列表
        /// </summary>
        private List<AppInfo> appInfoList;

        /// <summary>
        /// 应用列表
        /// </summary>
        public List<AppInfo> AppInfoList
        {
            get
            {
                return appInfoList;
            }
            set
            {
                appInfoList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 选中应用
        /// </summary>
        private AppInfo selectedAppInfo;

        /// <summary>
        /// 选中应用
        /// </summary>
        public AppInfo SelectedAppInfo
        {
            get
            {
                return selectedAppInfo;
            }
            set
            {
                selectedAppInfo = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region 绑定方法

        /// <summary>
        /// 正在关闭窗口
        /// </summary>
        public RelayCommand<CommandParameterEx> MainWindowClosingCommand => new RelayCommand<CommandParameterEx>(DoMainWindowClosing);

        /// <summary>
        /// 正在关闭窗口
        /// </summary>
        /// <param name="commandParameterEx">参数</param>
        private void DoMainWindowClosing(CommandParameterEx commandParameterEx)
        {
            // 转换参数
            var cancelEventArgs = commandParameterEx.EventArgs as CancelEventArgs;
            if (cancelEventArgs == null)
            {
                return;
            }

            AppGlobal.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            AppGlobal.MainWindow.ShowInTaskbar = false;
            cancelEventArgs.Cancel = true;
        }

        /// <summary>
        /// 点击新建
        /// </summary>
        public RelayCommand NewBtnClickCommand => new RelayCommand(DoNewBtnClickCommand);

        /// <summary>
        /// 点击新建
        /// </summary>
        private void DoNewBtnClickCommand()
        {
            
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="text">文本</param>
        private void ShowToolTip(string text)
        {
            var tempToolTip = new ToolTip();
            tempToolTip.Content = text;
            tempToolTip.StaysOpen = false;
            tempToolTip.IsOpen = true;
        }

        /// <summary>
        /// 重新加载
        /// </summary>
        private void ReLoad()
        {
            LoadConfig();
        }


        #endregion

        #region 公共方法

        /// <summary>
        /// 加载配置
        /// </summary>
        public void LoadConfig()
        {
        }

        #endregion
    }
}