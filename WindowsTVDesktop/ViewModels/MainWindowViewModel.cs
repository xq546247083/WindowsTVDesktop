using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using WindowsTVDesktop.Common;
using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Managers;

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
            SelectedApp = AppList?.FirstOrDefault();
        }

        #region 绑定属性

        /// <summary>
        /// 应用列表
        /// </summary>
        private List<AppViewModel> appList;

        /// <summary>
        /// 应用列表
        /// </summary>
        public List<AppViewModel> AppList
        {
            get
            {
                return appList;
            }
            set
            {
                appList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 选中应用
        /// </summary>
        private AppViewModel? selectedApp;

        /// <summary>
        /// 选中应用
        /// </summary>
        public AppViewModel? SelectedApp
        {
            get
            {
                return selectedApp;
            }
            set
            {
                selectedApp = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 应用大小
        /// </summary>
        private int itemSize;

        /// <summary>
        /// 应用大小
        /// </summary>
        public int ItemSize
        {
            get
            {
                return itemSize;
            }
            set
            {
                itemSize = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 屏幕分辨率
        /// </summary>
        private string screenResolution;

        /// <summary>
        /// 屏幕分辨率
        /// </summary>
        public string ScreenResolution
        {
            get
            {
                return screenResolution;
            }
            set
            {
                screenResolution = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 全局热键信息
        /// </summary>
        private string globalHotKeyMsg;

        /// <summary>
        /// 全局热键信息
        /// </summary>
        public string GlobalHotKeyMsg
        {
            get
            {
                return globalHotKeyMsg;
            }
            set
            {
                globalHotKeyMsg = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region 界面方法

        public RelayCommand DeleteCommand => new RelayCommand(Delete);

        private void Delete()
        {
            if (selectedApp == null || selectedApp.AppType != AppType.Desktop)
            {
                return;
            }

            var config = ConfigManager.GetConfig();
            config.AppInfoList.RemoveAll(r => r.StartPath == selectedApp.StartPath && r.AppType == Enum.AppType.Desktop);
            ConfigManager.Save(config);

            ReLoad();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            var config = ConfigManager.GetConfig();
            AppList = config.AppInfoList.Select(r => r.Turn()).OrderBy(r => r.Order).ToList();
            ItemSize = config.ItemSize;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 重新加载
        /// </summary>
        public void ReLoad()
        {
            LoadConfig();
        }

        public void MainWindow_KeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                selectedApp?.Click();
            }
        }

        public void AppListBox_MouseLeftButtonUp()
        {
            selectedApp?.Click();
        }

        public void MainWindow_Activated()
        {
            var screenWidth = System.Windows.Forms.Screen.PrimaryScreen?.Bounds.Width;
            var screenHeight = System.Windows.Forms.Screen.PrimaryScreen?.Bounds.Height;
            ScreenResolution = $"{screenWidth}*{screenHeight}";
        }

        #endregion
    }
}