using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using WindowsTVDesktop.Common;
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
            SelectedApp = AppList.FirstOrDefault();
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
        private AppViewModel selectedApp;

        /// <summary>
        /// 选中应用
        /// </summary>
        public AppViewModel SelectedApp
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
        private int appSize;

        /// <summary>
        /// 应用大小
        /// </summary>
        public int AppSize
        {
            get
            {
                return appSize;
            }
            set
            {
                appSize = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region 绑定方法

        /// <summary>
        /// 配置
        /// </summary>
        public RelayCommand ConfigCommand => new RelayCommand(ClickConfig);

        /// <summary>
        /// 配置
        /// </summary>
        private void ClickConfig()
        {

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
            AppSize = config.AppSize;
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

        /// <summary>
        /// 点击按钮
        /// </summary>
        /// <param name="e"></param>
        public void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                selectedApp.Click();
            }
            else if (e.Key == Key.Apps)
            {
                MessageBox.Show("点击菜单键");
            }
        }

        #endregion
    }
}