using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Managers;

namespace WindowsTVDesktop.ViewModels
{
    /// <summary>
    /// 主界面的ViewModel
    /// </summary>
    public class ConfigWindowViewModel : ObservableObject
    {
        private string? oldSelectedConfigName;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ConfigWindowViewModel()
        {
            ReLoad();
            SelectedConfig = ConfigList?.FirstOrDefault();
        }

        #region 绑定属性

        /// <summary>
        /// 列表
        /// </summary>
        private List<ConfigViewModel> configList;

        /// <summary>
        /// 列表
        /// </summary>
        public List<ConfigViewModel> ConfigList
        {
            get
            {
                return configList;
            }
            set
            {
                configList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 选中
        /// </summary>
        private ConfigViewModel? selectedConfig;

        /// <summary>
        /// 选中
        /// </summary>
        public ConfigViewModel? SelectedConfig
        {
            get
            {
                return selectedConfig;
            }
            set
            {
                selectedConfig = value;
                OnPropertyChanged();

                if (value != null) 
                {
                    oldSelectedConfigName = value.Name;
                }
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

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            var config = ConfigManager.GetConfig();
            ConfigList =
            [
                //new ConfigViewModel() { Name = "全屏显示：", Data = config.FullScreen, Order = 2, ConfigType = ConfigType.FullScreen },
                new ConfigViewModel() { Name = "变大", Order = 3, ConfigType = ConfigType.AddItemSize },
                new ConfigViewModel() { Name = "变小", Order = 4, ConfigType = ConfigType.SubItemSize },
                new ConfigViewModel() { Name = "开机自启动：", Data = TaskSchedulerManager.GetIsLaunchOnSysPowerOnByTaskScheduler(), Order = 1, ConfigType = ConfigType.AutoStart },
                new ConfigViewModel() { Name = "关闭", Order = 5, ConfigType = ConfigType.Close },
            ];

            ItemSize = config.ItemSize;
            SelectedConfig = ConfigList.FirstOrDefault(r => r.Name == oldSelectedConfigName);
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

        public void ConfigListBox_MouseLeftButtonUp()
        {
            selectedConfig?.Click();
            ReLoad();
        }

        public void ConfigWindow_KeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                selectedConfig?.Click();
                ReLoad();
            }
        }

        #endregion
    }
}